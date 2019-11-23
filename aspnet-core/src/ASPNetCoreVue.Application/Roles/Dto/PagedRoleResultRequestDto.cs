using Abp.Application.Services.Dto;

namespace ASPNetCoreVue.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

