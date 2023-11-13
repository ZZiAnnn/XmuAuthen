namespace NetCourse.Framework.Security
{
    public interface IUserPrincipal
    {
        #region 字段
        Guid ID { get; set; }
        string Realname { get; set; }
        string Avatar {  get; set; }
        #endregion
    }
}
