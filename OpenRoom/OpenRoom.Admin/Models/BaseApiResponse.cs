namespace OpenRoom.Admin.Models;

public class BaseApiResponse
{
    public BaseApiResponse()
    {
        
    }
    public BaseApiResponse(object body) //�w�p�n���ȡA�i�]�p���Ѽƪ��غc���A�ʸ˪��Ϊk
    {
        Body = body;
        IsSuccess = true;
    }

    //�ۤv�g���^�ǡA�R�X�h�Oapi, �p200�N�|���o��ӡAbod��object�N�n�]��JSON serilize...�N�n
    public bool IsSuccess { get; set; }
    public object Body { get; set; }
    public string Message { get; set; }
}