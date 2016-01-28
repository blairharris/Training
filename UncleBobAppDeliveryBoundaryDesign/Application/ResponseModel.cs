namespace Application
{
    public class ResponseModel
    {
        public virtual string Output { get; set; }
    }

    public class ResponseModelOk : ResponseModel
    {
        public ResponseModelOk(int sum)
        {
            Output = sum.ToString(); ;
        }

        public override string Output { get; set; }
    }

    public class ResponseModelError : ResponseModel
    {
        public ResponseModelError(string message)
        {
            Output = message;
        }

        public override string Output { get; set; }
    }
}
