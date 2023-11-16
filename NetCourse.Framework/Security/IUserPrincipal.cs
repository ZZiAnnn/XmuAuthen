namespace NetCourse.Framework.Security
{
    public interface IUserPrincipal
    {
        #region 字段
        Guid ID { get; set; }
        string UserName { get; set; }
        string StudentNo { get; set; }
        string Avatar {  get; set; }
        #endregion
    }
}
