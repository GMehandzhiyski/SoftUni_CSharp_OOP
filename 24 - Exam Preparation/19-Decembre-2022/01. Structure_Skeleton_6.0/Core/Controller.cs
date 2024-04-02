using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        private readonly SubjectRepository subjectRepository;
        private readonly StudentRepository studentRepository;
        private readonly UniversityRepository universityRepository;

        public Controller()
        {
            subjectRepository = new SubjectRepository();
            studentRepository = new StudentRepository();
            universityRepository = new UniversityRepository();
        }


        public string AddSubject(string subjectName, string subjectType)
        {
            if (subjectType != "EconomicalSubject"
                && subjectType != "HumanitySubject"
                && subjectType != "TechnicalSubject")
            {
                return string.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }

            if (subjectRepository.FindByName(subjectName) != null)
            {
                return string.Format(OutputMessages.AlreadyAddedSubject, subjectName);
            }

            ISubject subject = null;
            int subjectId = subjectRepository.Models.Count + 1;

            if (subjectType == nameof(EconomicalSubject))
            {
                subject = new EconomicalSubject(subjectId, subjectName);
            }
            else if (subjectType == nameof(HumanitySubject))
            {
                subject = new HumanitySubject(subjectId, subjectName);
            }
            else if (subjectType == nameof(TechnicalSubject))
            {
                subject = new TechnicalSubject(subjectId, subjectName);
            }

            subjectRepository.AddModel(subject);



            return string.Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName, nameof(SubjectRepository)).Trim();
        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            if (universityRepository.FindByName(universityName) != null)
            {
                return string.Format(OutputMessages.AlreadyAddedSubject, universityName);
            }

            List<int> rs = new List<int>();
            foreach (var subName in requiredSubjects)
            {
                rs.Add(subjectRepository.FindByName(subName).Id);
            }

            IUniversity university = new University(universityRepository.Models.Count + 1, universityName, category, capacity, rs);
            universityRepository.AddModel(university);

            return string.Format(OutputMessages.UniversityAddedSuccessfully, universityName, nameof(UniversityRepository));

        }

        public string AddStudent(string firstName, string lastName)
        {
            string result = "";
            string fullName = firstName + " " + lastName;

            if (studentRepository.FindByName(fullName) != null)
            {
                result = string.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);
            }
            else
            {
                IStudent student = new Student(studentRepository.Models.Count + 1, firstName, lastName);
                studentRepository.AddModel(student);    
                result = string.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, nameof(StudentRepository));
            }


            return result.Trim();
        }

        public string TakeExam(int studentId, int subjectId)
        {
            string result = "";
            IStudent currStudent = studentRepository.FindById(studentId);
            ISubject currSubject = subjectRepository.FindById(subjectId);

            if (currStudent.Id == null)
            {
                result = string.Format(OutputMessages.InvalidStudentId);
            }

            else if (currSubject.Id == null)
            {
                result = string.Format(OutputMessages.InvalidSubjectId);
            }

            else if (currStudent.Id == studentId
                && currSubject.Id != subjectId)
            {
                result = string.Format(OutputMessages.StudentAlreadyCoveredThatExam, currStudent.FirstName, currStudent.LastName, currSubject.Name);
            }

            else
            {
                currStudent.CoverExam(currSubject);
                result = string.Format(OutputMessages.StudentSuccessfullyCoveredExam, currStudent.FirstName, currStudent.LastName, currSubject.Name);
            }

            return result.Trim();
        }


        public string ApplyToUniversity(string studentName, string universityName)
        {
            string result = default;
            string firstName = studentName.Split(" ")[0];
            string LastName = studentName.Split(" ")[1];

            IStudent currStudent = studentRepository.FindByName(studentName);
            IUniversity currUniversity = universityRepository.FindByName(universityName);

            if (currStudent == default)
            {
                result = string.Format(OutputMessages.StudentNotRegitered,firstName, LastName);
            }

            else if (currUniversity == default)
            {
                result = string.Format(OutputMessages.UniversityNotRegitered,universityName);
            }

            else if (!currUniversity.RequiredSubjects.All(x => currStudent.CoveredExams.Any(e => e == x)))
            {
                result = string.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName);
            }

            else if (currStudent.University != default
                && currUniversity.Name == universityName)  
            {
                result = string.Format(OutputMessages.StudentAlreadyJoined, firstName, LastName, universityName);
            }

            else
            {
                currStudent.JoinUniversity(currUniversity);
                result = string.Format(OutputMessages.StudentSuccessfullyJoined, firstName, LastName, universityName);
            }


            return result.Trim();
        }


        public string UniversityReport(int universityId)
        {
            IUniversity currUniversity = universityRepository.FindById(universityId);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"*** {currUniversity.Name} ***");
            sb.AppendLine($"Profile: {currUniversity.Category}");
            int studentCount = studentRepository.Models.Where(s => s.University == currUniversity).Count();
            sb.AppendLine($"Students admitted: {studentCount}");
            sb.AppendLine($"University vacancy: {currUniversity.Capacity - studentCount}");
           
            return sb.ToString().Trim();
            
        }
    }
}
