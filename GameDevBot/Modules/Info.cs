﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Discord.Rest;


namespace GameDevBot.Modules
{
    public class Info : ModuleBase
    {

        // ~say hello -> hello
        [Command("say"), Summary("Echos a message.")]
        public async Task Say([Remainder, Summary("The text to echo")] string echo)
        {
            // ReplyAsync is a method on ModuleBase
            await ReplyAsync(echo);
        }

        [Command("courses"), Summary("Test of function")]
        public async Task Courses()
        {
            await Context.Channel.SendMessageAsync("Blender,Unreal,Unity,RPG,Physics,Unity VR,Gimp");
 //           await Task.Delay(1);

        }

        [Command("test")]
        public async Task Test(IGuildUser user)
        {
            await Context.Channel.SendMessageAsync(user.ToString());
        }

        [Command("addrole")]
        public static async Task AddRolesAsync(IGuildUser user, BaseDiscordClient client, IEnumerable<IRole> roles, RequestOptions options)
        {
            //foreach (var role in roles)
 //               await client.ApiClient.AddRoleAsync(user.Guild.Id, user.Id, role.Id, options);
        }

        // ~sample square 20 -> 400
        [Command("square"), Summary("Squares a number.")]
        public async Task Square([Summary("The number to square.")] int num)
        {
            // We can also access the channel from the Command Context.
            await Context.Channel.SendMessageAsync($"{num}^2 = {Math.Pow(num, 2)}");
        }

        // ~sample userinfo --> foxbot#0282
        // ~sample userinfo @Khionu --> Khionu#8708
        // ~sample userinfo Khionu#8708 --> Khionu#8708
        // ~sample userinfo Khionu --> Khionu#8708
        // ~sample userinfo 96642168176807936 --> Khionu#8708
        // ~sample whois 96642168176807936 --> Khionu#8708
        [Command("userinfo"), Summary("Returns info about the current user, or the user parameter, if one passed.")]
        [Alias("user", "whois")]
        public async Task UserInfo([Summary("The (optional) user to get info for")] IUser user = null)
        {
            var userInfo = user ?? Context.Client.CurrentUser;
            await ReplyAsync($"{userInfo.Username}#{userInfo.Discriminator}");
            
        }
    }
}
