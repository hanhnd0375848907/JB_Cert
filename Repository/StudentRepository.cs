using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IStudentRepository
    {
        List<StudentModel> GetAll();

        int AddStudent(StudentModel studentModel);

        string GetImage(int studentId);

        StudentModel GetSingleStudentById(int studentId);

        int UpdateStudent(StudentModel studentModel);

        int DeleteStudent(int studentId);

        List<StudentModel> SearchByNameAndSchool(string studentName, int schoolId);

        List<StudentModel> SearchByName(string studentName);

        List<StudentModel> SearchStudent(string fullname, int schoolId, string identityNumber, int graduatingYear);

        List<StudentModel> SearchStudentForAddingCert(string studentName, int schoolId);

    }
    public class StudentRepository : IStudentRepository
    {
        SqlConnection conn;

        public int AddStudent(StudentModel studentModel)
        {
            using(conn = JBCertConnection.Instance)
            {
                string queryString = "AddStudent_Proc";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    sqlCommand.Parameters.AddWithValue("@TruongId", studentModel.SchoolId);
                    sqlCommand.Parameters.AddWithValue("@DantocId", studentModel.EthnicId);
                    sqlCommand.Parameters.AddWithValue("@Ten", studentModel.FullName);
                    sqlCommand.Parameters.AddWithValue("@Diachi", studentModel.Address);
                    sqlCommand.Parameters.AddWithValue("@Ngaysinh", studentModel.Dob);
                    sqlCommand.Parameters.AddWithValue("@Hokhau", studentModel.HouseHold);
                    sqlCommand.Parameters.AddWithValue("@CMT", studentModel.IdentityNumber);
                    sqlCommand.Parameters.AddWithValue("@GioiTinh", studentModel.Gender);
                    sqlCommand.Parameters.AddWithValue("@Ghichu", studentModel.Note);
                    sqlCommand.Parameters.AddWithValue("@Anh", studentModel.Image);
                    sqlCommand.Parameters.AddWithValue("@Score", studentModel.Score);
                    sqlCommand.Parameters.AddWithValue("@LoaiId", studentModel.BlankCertTypeId);
                    sqlCommand.Parameters.AddWithValue("@Namtotnghiep", studentModel.GraduatingYear);
                    sqlCommand.Parameters.AddWithValue("@NganhdaotaoId", studentModel.MajorId);
                    sqlCommand.Parameters.AddWithValue("@HinhthucdaotaoId", studentModel.LearningModeId);
                    sqlCommand.Parameters.AddWithValue("@Noisinh", studentModel.BornedAddress);
                    sqlCommand.Parameters.AddWithValue("@XeploaiId", studentModel.RankingId);

                    int rowEffected = sqlCommand.ExecuteNonQuery();
                    return rowEffected;

                }
                catch(Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public string GetImage(int studentId)
        {
            string imageName = "";
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"SELECT TOP 1000 [Id] ,[Anh]
                                  FROM[jb_cert].[dbo].[tblHocsinh] where id = @Id";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Id", studentId);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    if (sqlDataReader.Read())
                    {
                        imageName = sqlDataReader["Anh"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    sqlDataReader.Close();
                    conn.Close();
                }
            }
            return imageName;
        }

        public List<StudentModel> GetAll()
        {
            List<StudentModel> studentModels = new List<StudentModel>(); 
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"SELECT a.*, b.Tentruong, c.Hinhthucdaotao, d.TenDantoc, e.name as 'Tenloai', f.Tenxeploai
                                      FROM [jb_cert].[dbo].[tblHocsinh] as a Left join [jb_cert].[dbo].[tblTruong] as b
                                      On a.[TruongId] = b.[Id] 
                                      Left join [jb_cert].[dbo].[tblHinhthucdaotao] as c
                                      on a.HinhthucdaotaoId = c.Id
                                      left join [jb_cert].[dbo].[tblDantoc] as d
                                      on a.DantocId = d.Id
                                      left join [jb_cert].[dbo].[tblLoai] as e
                                      on a.LoaiId = e.Id
                                      left join [jb_cert].[dbo].[tblXeploai] as f
                                      on a.XeploaiId = f.Id
                                      Where a.[IsDeleted] = 0";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    while (sqlDataReader.Read())
                    {
                        StudentModel studentModel = new StudentModel();
                        studentModel.Id = int.Parse(sqlDataReader["Id"].ToString());
                        studentModel.SchoolId = int.Parse(sqlDataReader["TruongId"].ToString());
                        studentModel.SchoolName = sqlDataReader["Tentruong"].ToString();
                        studentModel.EthnicId = int.Parse(sqlDataReader["DantocId"].ToString());
                        studentModel.EthnicName = sqlDataReader["Tendantoc"].ToString();
                        studentModel.FullName = sqlDataReader["Ten"].ToString();
                        studentModel.Address = sqlDataReader["Diachi"].ToString();
                        studentModel.Dob = DateTime.Parse(sqlDataReader["Ngaysinh"].ToString());
                        studentModel.HouseHold = sqlDataReader["Hokhau"].ToString();
                        studentModel.IdentityNumber = sqlDataReader["CMT"].ToString();
                        studentModel.Gender = sqlDataReader["Gioitinh"].ToString();
                        studentModel.Note = sqlDataReader["Ghichu"].ToString();
                        studentModel.Image = sqlDataReader["Anh"].ToString();
                        studentModel.IsDeleted = false;
                        studentModel.BlankCertTypeId = int.Parse(sqlDataReader["LoaiId"].ToString());
                        studentModel.BlankCertTypeName = sqlDataReader["Tenloai"].ToString();
                        studentModel.BornedAddress = sqlDataReader["Noisinh"].ToString();
                        studentModel.LearningModeId = int.Parse(sqlDataReader["HinhthucdaotaoId"].ToString());
                        studentModel.LearningModeName = sqlDataReader["Hinhthucdaotao"].ToString();
                        studentModel.Score = float.Parse(sqlDataReader["Score"].ToString());
                        studentModel.MajorId = int.Parse(sqlDataReader["NganhdaotaoId"].ToString());
                        studentModel.GraduatingYear = int.Parse(sqlDataReader["Namtotnghiep"].ToString());
                        studentModel.RankingId = int.Parse(sqlDataReader["XeploaiId"].ToString());
                        studentModel.RankingName = sqlDataReader["Tenxeploai"].ToString();

                        studentModels.Add(studentModel);
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    sqlDataReader.Close();
                    conn.Close();
                }
            }

            return studentModels;
        }

        public StudentModel GetSingleStudentById(int studentId)
        {
            StudentModel studentModel = new StudentModel();

            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"SELECT a.*, b.Tentruong, c.Hinhthucdaotao, d.TenDantoc, e.name as 'Tenloai', f.Tenxeploai
                                      FROM [jb_cert].[dbo].[tblHocsinh] as a Left join [jb_cert].[dbo].[tblTruong] as b
                                      On a.[TruongId] = b.[Id] 
                                      Left join [jb_cert].[dbo].[tblHinhthucdaotao] as c
                                      on a.HinhthucdaotaoId = c.Id
                                      left join [jb_cert].[dbo].[tblDantoc] as d
                                      on a.DantocId = d.Id
                                      left join [jb_cert].[dbo].[tblLoai] as e
                                      on a.LoaiId = e.Id
                                      left join [jb_cert].[dbo].[tblXeploai] as f
                                      on a.XeploaiId = f.Id
                                      Where a.[Id] = @StudentId";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@StudentId", studentId);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    if (sqlDataReader.Read())
                    {
                        studentModel.Id = int.Parse(sqlDataReader["Id"].ToString());
                        studentModel.SchoolId = int.Parse(sqlDataReader["TruongId"].ToString());
                        studentModel.SchoolName = sqlDataReader["Tentruong"].ToString();
                        studentModel.EthnicId = int.Parse(sqlDataReader["DantocId"].ToString());
                        studentModel.EthnicName = sqlDataReader["Tendantoc"].ToString();
                        studentModel.FullName = sqlDataReader["Ten"].ToString();
                        studentModel.Address = sqlDataReader["Diachi"].ToString();
                        studentModel.Dob = DateTime.Parse(sqlDataReader["Ngaysinh"].ToString());
                        studentModel.HouseHold = sqlDataReader["Hokhau"].ToString();
                        studentModel.IdentityNumber = sqlDataReader["CMT"].ToString();
                        studentModel.Gender = sqlDataReader["Gioitinh"].ToString();
                        studentModel.Note = sqlDataReader["Ghichu"].ToString();
                        studentModel.Image = sqlDataReader["Anh"].ToString();
                        studentModel.IsDeleted = false;
                        studentModel.BlankCertTypeId = int.Parse(sqlDataReader["LoaiId"].ToString());
                        studentModel.BlankCertTypeName = sqlDataReader["Tenloai"].ToString();
                        studentModel.BornedAddress = sqlDataReader["Noisinh"].ToString();
                        studentModel.LearningModeId = int.Parse(sqlDataReader["HinhthucdaotaoId"].ToString());
                        studentModel.LearningModeName = sqlDataReader["Hinhthucdaotao"].ToString();
                        studentModel.Score = float.Parse(sqlDataReader["Score"].ToString());
                        studentModel.MajorId = int.Parse(sqlDataReader["NganhdaotaoId"].ToString());
                        studentModel.GraduatingYear = int.Parse(sqlDataReader["Namtotnghiep"].ToString());
                        studentModel.RankingId = int.Parse(sqlDataReader["XeploaiId"].ToString());
                        studentModel.RankingName = sqlDataReader["Tenxeploai"].ToString();

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    sqlDataReader.Close();
                    conn.Close();
                }
            }

            return studentModel;
        }

        public int UpdateStudent(StudentModel studentModel)
        {
            using(conn = JBCertConnection.Instance)
            {
                string queryString = "UpdateStudent_Proc";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    sqlCommand.Parameters.AddWithValue("@StudentId", studentModel.Id);
                    sqlCommand.Parameters.AddWithValue("@TruongId", studentModel.SchoolId);
                    sqlCommand.Parameters.AddWithValue("@DantocId", studentModel.EthnicId);
                    sqlCommand.Parameters.AddWithValue("@Ten", studentModel.FullName);
                    sqlCommand.Parameters.AddWithValue("@Diachi", studentModel.Address);
                    sqlCommand.Parameters.AddWithValue("@Ngaysinh", studentModel.Dob);
                    sqlCommand.Parameters.AddWithValue("@Hokhau", studentModel.HouseHold);
                    sqlCommand.Parameters.AddWithValue("@CMT", studentModel.IdentityNumber);
                    sqlCommand.Parameters.AddWithValue("@GioiTinh", studentModel.Gender);
                    sqlCommand.Parameters.AddWithValue("@Ghichu", studentModel.Note);
                    sqlCommand.Parameters.AddWithValue("@Anh", studentModel.Image);
                    sqlCommand.Parameters.AddWithValue("@Score", studentModel.Score);
                    sqlCommand.Parameters.AddWithValue("@LoaiId", studentModel.BlankCertTypeId);
                    sqlCommand.Parameters.AddWithValue("@Namtotnghiep", studentModel.GraduatingYear);
                    sqlCommand.Parameters.AddWithValue("@NganhdaotaoId", studentModel.MajorId);
                    sqlCommand.Parameters.AddWithValue("@HinhthucdaotaoId", studentModel.LearningModeId);
                    sqlCommand.Parameters.AddWithValue("@Noisinh", studentModel.BornedAddress);
                    sqlCommand.Parameters.AddWithValue("@XeploaiId", studentModel.RankingId);

                    int rowEffected = sqlCommand.ExecuteNonQuery();
                    return rowEffected;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public int DeleteStudent(int studentId)
        {
            using(conn = JBCertConnection.Instance)
            {
                string queryString = @"Update [tblHocsinh]
                                        Set [tblHocsinh].[IsDeleted] = 1
                                        Where Id = @StudentId";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@StudentId", studentId);
                try
                {
                    int rowEffected = sqlCommand.ExecuteNonQuery();
                    return rowEffected;
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public List<StudentModel> SearchByNameAndSchool(string studentName, int schoolId)
        {
            List<StudentModel> studentModels = new List<StudentModel>();
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"SELECT a.*, b.Tentruong, c.Hinhthucdaotao, d.TenDantoc, e.name as 'Tenloai', f.Tenxeploai
                                      FROM [jb_cert].[dbo].[tblHocsinh] as a Left join [jb_cert].[dbo].[tblTruong] as b
                                      On a.[TruongId] = b.[Id] 
                                      Left join [jb_cert].[dbo].[tblHinhthucdaotao] as c
                                      on a.HinhthucdaotaoId = c.Id
                                      left join [jb_cert].[dbo].[tblDantoc] as d
                                      on a.DantocId = d.Id
                                      left join [jb_cert].[dbo].[tblLoai] as e
                                      on a.LoaiId = e.Id
                                      left join [jb_cert].[dbo].[tblXeploai] as f
                                      on a.XeploaiId = f.Id
                                      Where a.[IsDeleted] = 0 and a.[Ten] like @StudentName and a.[TruongId] = @SchoolId";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@StudentName", "%" + studentName + "%");
                sqlCommand.Parameters.AddWithValue("@SchoolId", schoolId);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    while (sqlDataReader.Read())
                    {
                        StudentModel studentModel = new StudentModel();
                        studentModel.Id = int.Parse(sqlDataReader["Id"].ToString());
                        studentModel.SchoolId = int.Parse(sqlDataReader["TruongId"].ToString());
                        studentModel.SchoolName = sqlDataReader["Tentruong"].ToString();
                        studentModel.EthnicId = int.Parse(sqlDataReader["DantocId"].ToString());
                        studentModel.EthnicName = sqlDataReader["Tendantoc"].ToString();
                        studentModel.FullName = sqlDataReader["Ten"].ToString();
                        studentModel.Address = sqlDataReader["Diachi"].ToString();
                        studentModel.Dob = DateTime.Parse(sqlDataReader["Ngaysinh"].ToString());
                        studentModel.HouseHold = sqlDataReader["Hokhau"].ToString();
                        studentModel.IdentityNumber = sqlDataReader["CMT"].ToString();
                        studentModel.Gender = sqlDataReader["Gioitinh"].ToString();
                        studentModel.Note = sqlDataReader["Ghichu"].ToString();
                        studentModel.Image = sqlDataReader["Anh"].ToString();
                        studentModel.IsDeleted = false;
                        studentModel.BlankCertTypeId = int.Parse(sqlDataReader["LoaiId"].ToString());
                        studentModel.BlankCertTypeName = sqlDataReader["Tenloai"].ToString();
                        studentModel.BornedAddress = sqlDataReader["Noisinh"].ToString();
                        studentModel.LearningModeId = int.Parse(sqlDataReader["HinhthucdaotaoId"].ToString());
                        studentModel.LearningModeName = sqlDataReader["Hinhthucdaotao"].ToString();
                        studentModel.Score = float.Parse(sqlDataReader["Score"].ToString());
                        studentModel.MajorId = int.Parse(sqlDataReader["NganhdaotaoId"].ToString());
                        studentModel.GraduatingYear = int.Parse(sqlDataReader["Namtotnghiep"].ToString());
                        studentModel.RankingId = int.Parse(sqlDataReader["XeploaiId"].ToString());
                        studentModel.RankingName = sqlDataReader["Tenxeploai"].ToString();
       
                        studentModels.Add(studentModel);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    sqlDataReader.Close();
                    conn.Close();
                }
            }

            return studentModels;
        }

        public List<StudentModel> SearchByName(string studentName)
        {
            List<StudentModel> studentModels = new List<StudentModel>();
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"SELECT a.*, b.Tentruong, c.Hinhthucdaotao, d.TenDantoc, e.name as 'Tenloai', f.Tenxeploai
                                      FROM [jb_cert].[dbo].[tblHocsinh] as a Left join [jb_cert].[dbo].[tblTruong] as b
                                      On a.[TruongId] = b.[Id] 
                                      Left join [jb_cert].[dbo].[tblHinhthucdaotao] as c
                                      on a.HinhthucdaotaoId = c.Id
                                      left join [jb_cert].[dbo].[tblDantoc] as d
                                      on a.DantocId = d.Id
                                      left join [jb_cert].[dbo].[tblLoai] as e
                                      on a.LoaiId = e.Id
                                      left join [jb_cert].[dbo].[tblXeploai] as f
                                      on a.XeploaiId = f.Id
                                      Where a.[IsDeleted] = 0 and a.[Ten] like @StudentName";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@StudentName", "%" + studentName + "%");

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    while (sqlDataReader.Read())
                    {
                        StudentModel studentModel = new StudentModel();
                        studentModel.Id = int.Parse(sqlDataReader["Id"].ToString());
                        studentModel.SchoolId = int.Parse(sqlDataReader["TruongId"].ToString());
                        studentModel.SchoolName = sqlDataReader["Tentruong"].ToString();
                        studentModel.EthnicId = int.Parse(sqlDataReader["DantocId"].ToString());
                        studentModel.EthnicName = sqlDataReader["Tendantoc"].ToString();
                        studentModel.FullName = sqlDataReader["Ten"].ToString();
                        studentModel.Address = sqlDataReader["Diachi"].ToString();
                        studentModel.Dob = DateTime.Parse(sqlDataReader["Ngaysinh"].ToString());
                        studentModel.HouseHold = sqlDataReader["Hokhau"].ToString();
                        studentModel.IdentityNumber = sqlDataReader["CMT"].ToString();
                        studentModel.Gender = sqlDataReader["Gioitinh"].ToString();
                        studentModel.Note = sqlDataReader["Ghichu"].ToString();
                        studentModel.Image = sqlDataReader["Anh"].ToString();
                        studentModel.IsDeleted = false;
                        studentModel.BlankCertTypeId = int.Parse(sqlDataReader["LoaiId"].ToString());
                        studentModel.BlankCertTypeName = sqlDataReader["Tenloai"].ToString();
                        studentModel.BornedAddress = sqlDataReader["Noisinh"].ToString();
                        studentModel.LearningModeId = int.Parse(sqlDataReader["HinhthucdaotaoId"].ToString());
                        studentModel.LearningModeName = sqlDataReader["Hinhthucdaotao"].ToString();
                        studentModel.Score = float.Parse(sqlDataReader["Score"].ToString());
                        studentModel.MajorId = int.Parse(sqlDataReader["NganhdaotaoId"].ToString());
                        studentModel.GraduatingYear = int.Parse(sqlDataReader["Namtotnghiep"].ToString());
                        studentModel.RankingId = int.Parse(sqlDataReader["XeploaiId"].ToString());
                        studentModel.RankingName = sqlDataReader["Tenxeploai"].ToString();

                        studentModels.Add(studentModel);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    sqlDataReader.Close();
                    conn.Close();
                }
            }

            return studentModels;
        }

        public List<StudentModel> SearchStudentForAddingCert(string studentName, int schoolId)
        {
            List<StudentModel> studentModels = new List<StudentModel>();
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"SELECT *, b.Tenxeploai FROM [dbo].[tblHocsinh] as a
		                                left join [dbo].[tblXeploai] as b
		                                on a.XeploaiId = b.Id
		                                where a.[IsDeleted] = 0 and a.[Ten] like @StudentName
		                                and a.Id not in (select HocsinhId from [dbo].[tblBang] where LoaiId = a.LoaiId and IsDeleted = 0 )";
                string queryString1 = @"SELECT *, b.Tenxeploai FROM [dbo].[tblHocsinh] as a
		                                left join [dbo].[tblXeploai] as b
		                                on a.XeploaiId = b.Id
		                                where a.[IsDeleted] = 0 and a.[Ten] like @StudentName and a.[TruongId] = @SchoolId
		                                and a.Id not in (select HocsinhId from [dbo].[tblBang] where LoaiId = a.LoaiId and IsDeleted = 0 )";
                conn.Open();
                SqlCommand sqlCommand;
                if (schoolId == -1)
                {
                    sqlCommand = new SqlCommand(queryString, conn);
                    sqlCommand.Parameters.AddWithValue("@StudentName", "%" + studentName + "%");
                }
                else
                {
                    sqlCommand = new SqlCommand(queryString1, conn);
                    sqlCommand.Parameters.AddWithValue("@StudentName", "%" + studentName + "%");
                    sqlCommand.Parameters.AddWithValue("@SchoolId", schoolId);
                }
                sqlCommand.CommandType = CommandType.Text;

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    while (sqlDataReader.Read())
                    {
                        StudentModel studentModel = new StudentModel();
                        studentModel.Id = int.Parse(sqlDataReader["Id"].ToString());
                        studentModel.SchoolId = int.Parse(sqlDataReader["TruongId"].ToString());
                        studentModel.EthnicId = int.Parse(sqlDataReader["DantocId"].ToString());
                        studentModel.FullName = sqlDataReader["Ten"].ToString();
                        studentModel.IdentityNumber = sqlDataReader["CMT"].ToString();
                        studentModel.Gender = sqlDataReader["Gioitinh"].ToString();
                        studentModel.Image = sqlDataReader["Anh"].ToString();
                        studentModel.IsDeleted = false;
                        studentModel.RankingId = int.Parse(sqlDataReader["XeploaiId"].ToString());
                        studentModel.RankingName = sqlDataReader["Tenxeploai"].ToString();

                        studentModels.Add(studentModel);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    sqlDataReader.Close();
                    conn.Close();
                }
            }

            return studentModels;
        }

        public List<StudentModel> SearchStudent(string fullname, int schoolId, string identityNumber, int graduatingYear)
        {
            List<StudentModel> studentModels = new List<StudentModel>();
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"SELECT a.*, b.Tentruong, c.Hinhthucdaotao, d.TenDantoc, e.name as 'Tenloai', f.Tenxeploai
                                      FROM [jb_cert].[dbo].[tblHocsinh] as a Left join [jb_cert].[dbo].[tblTruong] as b
                                      On a.[TruongId] = b.[Id] 
                                      Left join [jb_cert].[dbo].[tblHinhthucdaotao] as c
                                      on a.HinhthucdaotaoId = c.Id
                                      left join [jb_cert].[dbo].[tblDantoc] as d
                                      on a.DantocId = d.Id
                                      left join [jb_cert].[dbo].[tblLoai] as e
                                      on a.LoaiId = e.Id
                                      left join [jb_cert].[dbo].[tblXeploai] as f
                                      on a.XeploaiId = f.Id
                                      Where a.[IsDeleted] = 0 
                                        and a.[Ten] like @StudentName 
                                        and (@SchoolId = -1 or a.[TruongId] = @SchoolId)
                                        and a.[CMT] like @CMT
                                        and (@GraduatingYear = -1 or a.[Namtotnghiep] = @GraduatingYear)";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@StudentName", "%" + fullname + "%");
                sqlCommand.Parameters.AddWithValue("@SchoolId", schoolId);
                sqlCommand.Parameters.AddWithValue("@CMT", "%" + identityNumber + "%");
                sqlCommand.Parameters.AddWithValue("@GraduatingYear", graduatingYear);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    while (sqlDataReader.Read())
                    {
                        StudentModel studentModel = new StudentModel();
                        studentModel.Id = int.Parse(sqlDataReader["Id"].ToString());
                        studentModel.SchoolId = int.Parse(sqlDataReader["TruongId"].ToString());
                        studentModel.SchoolName = sqlDataReader["Tentruong"].ToString();
                        studentModel.EthnicId = int.Parse(sqlDataReader["DantocId"].ToString());
                        studentModel.EthnicName = sqlDataReader["Tendantoc"].ToString();
                        studentModel.FullName = sqlDataReader["Ten"].ToString();
                        studentModel.Address = sqlDataReader["Diachi"].ToString();
                        studentModel.Dob = DateTime.Parse(sqlDataReader["Ngaysinh"].ToString());
                        studentModel.HouseHold = sqlDataReader["Hokhau"].ToString();
                        studentModel.IdentityNumber = sqlDataReader["CMT"].ToString();
                        studentModel.Gender = sqlDataReader["Gioitinh"].ToString();
                        studentModel.Note = sqlDataReader["Ghichu"].ToString();
                        studentModel.Image = sqlDataReader["Anh"].ToString();
                        studentModel.IsDeleted = false;
                        studentModel.BlankCertTypeId = int.Parse(sqlDataReader["LoaiId"].ToString());
                        studentModel.BlankCertTypeName = sqlDataReader["Tenloai"].ToString();
                        studentModel.BornedAddress = sqlDataReader["Noisinh"].ToString();
                        studentModel.LearningModeId = int.Parse(sqlDataReader["HinhthucdaotaoId"].ToString());
                        studentModel.LearningModeName = sqlDataReader["Hinhthucdaotao"].ToString();
                        studentModel.Score = float.Parse(sqlDataReader["Score"].ToString());
                        studentModel.MajorId = int.Parse(sqlDataReader["NganhdaotaoId"].ToString());
                        studentModel.GraduatingYear = int.Parse(sqlDataReader["Namtotnghiep"].ToString());
                        studentModel.RankingId = int.Parse(sqlDataReader["XeploaiId"].ToString());
                        studentModel.RankingName = sqlDataReader["Tenxeploai"].ToString();

                        studentModels.Add(studentModel);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    sqlDataReader.Close();
                    conn.Close();
                }
            }

            return studentModels;
        }
    }
}
