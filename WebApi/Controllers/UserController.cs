using Microsoft.AspNetCore.Mvc;

namespace WebApi.AddCntrollers
{

    [ApiController]
    [Route("[controller]s")]
    public class UserController : ControllerBase
    {
        private static List<User> UserList = new List<User>()
        {
            new User{
                UserId=1,
                UserName="Enes",
                UserSurname="Özcan",
                UserEmail="enes@gmail.com",
            },
            new User{
                UserId=2,
                UserName="Ali",
                UserSurname="Ata",
                UserEmail="ali@gmail.com",
            },
            new User{
                UserId=3,
                UserName="Mert",
                UserSurname="Yalabık",
                UserEmail="mert@gmail.com",
            },
        };
        [HttpGet]
        public List<User> GetUsers()
        {
            var userList = UserList.OrderBy(x=>x.UserId).ToList<User>();
            return userList;
        }
        [HttpGet("{id}")]
        public User GetById(int id)
        {
            var user = UserList.Where(user=>user.UserId==id).SingleOrDefault();
            return user;
        }
        [HttpPost]
        public  IActionResult AddUser([FromBody] User newUser)
        {
            var user =UserList.SingleOrDefault(x=>x.UserName == newUser.UserName);

            if(user is not null)
                return BadRequest();
            UserList.Add(newUser);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id,[FromBody] User updatedUser)
        {
            var user = UserList.SingleOrDefault(x=>x.UserId == id);
            if(user is null)
                return BadRequest();
            user.UserName = updatedUser.UserName != default ?  updatedUser.UserName : user.UserName;
            user.UserSurname = updatedUser.UserSurname != default ?  updatedUser.UserSurname : user.UserSurname;
            user.UserEmail = updatedUser.UserEmail != default ?  updatedUser.UserEmail : user.UserEmail;
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = UserList.SingleOrDefault(x=>x.UserId == id);
            if(user is null)
                return BadRequest();
            UserList.Remove(user);
            return Ok();
        }

    }
}