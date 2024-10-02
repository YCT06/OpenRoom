using System.Runtime.CompilerServices;
using OpenRoom.Admin.Constants;
using OpenRoom.Admin.Filters;
using OpenRoom.Admin.Helpers;
using OpenRoom.Admin.Models;
using OpenRoom.Admin.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OpenRoom.Admin.WebApi;

//[ApiController]
//[Route("/api/[controller]/[action]")]
[ApiExceptionFilter]
public class AuthController : BaseApiController //�i���~�Ӫ��覡�h��
{
    private readonly JwtHelper _jwt;
    private readonly UserMangerService _userMangerService;

    public AuthController(JwtHelper jwt, UserMangerService userMangerService)
    {
        _jwt = jwt;
        _userMangerService = userMangerService;
    }

    [HttpPost]
    [AllowAnonymous]
    public IActionResult Login(LoginInDTO request)
    {

        if (!_userMangerService.IsUserValid(request))
        {
            return Ok(new BaseApiResponse());//isSucess �Ofalse�Abody�Onull
        }

        return Ok(new BaseApiResponse(_jwt.GenerateToken(request.UserName, 10)));//�ⲣ�X�Ӫ�token�R�X�h�A10��10����
        
        //try
        //{
        //    if (!_userMangerService.IsUserValid(request))
        //    {
        //        return Ok(new BaseApiResponse());//isSucess �Ofalse�Abody�Onull
        //    }

        //    return Ok(new BaseApiResponse(_jwt.GenerateToken(request.UserName, 10)));//�ⲣ�X�Ӫ�token�R�X�h�A10��10����
        //}
        //catch (Exception ex)
        //{
        //    return Ok(new BaseApiResponse()
        //    {

        //        Message = ex.Message
        //    });
        //}
       
    }

    [HttpGet]
    [Authorize(Roles = AuthRole.Admin)]//���⪺�X�R�Aconst���U�sĶ�Abuild��۰ʴ��ȡCconst�Ȧ��ܡA�����n���s�ظm�L��readonly���P�Areadonly�O�bruntime
    public IActionResult GetUserName()
    {
        return Ok(new BaseApiResponse(_userMangerService.GetUserName()));//���ޫ��˳��^��200
    }

    [HttpGet]
    // [Authorize(Roles = "SuperAdmin")]
    [Authorize(Roles = AuthRole.SuperAdmin)]
    public IActionResult GetClaims()
    {
        return Ok(new BaseApiResponse(User.Claims.Select(x => new { x.Type, x.Value })));//���ޫ��˳��^��200
    }

    
}

public class LoginInDTO
{
    public string UserName { get; set; }
    public string Password { get; set; }
}