using CoreWiki.Extensibility.TheChapel;
using Xunit;

namespace CoreWiki.Test.TheChapel
{
    public class ProfanityFilterTests
    {
        [Fact]
        public void Test1()
        {
            var blockedWords = new[] {"BLUE", "RED", "WHITE"};
            var filter = new ProfanityFilter();

            var actual = filter.Remove(PreFilterString, blockedWords);

            Assert.Equal(PostFilterStringWithReplacements, actual);
        }

        private const string PreFilterString =
            @"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. A condimentum vitae sapien pellentesque habitant morbi tristique senectus. Sed arcu non odio euismod lacinia at quis. Nam aliquam sem et tortor consequat id. Donec ac odio tempor orci dapibus ultrices in. Sodales ut eu sem integer vitae justo eget magna fermentum. Facilisi cras fermentum odio eu feugiat. Egestas egestas fringilla phasellus faucibus scelerisque. Viverra tellus in hac habitasse platea dictumst vestibulum. Pulvinar elementum integer enim neque volutpat ac tincidunt. Vel elit scelerisque mauris pellentesque pulvinar pellentesque habitant morbi. Integer eget aliquet nibh praesent. In fermentum et sollicitudin ac. Posuere sollicitudin aliquam ultrices sagittis orci a scelerisque purus semper. Luctus venenatis lectus magna fringilla urna porttitor. Adipiscing elit pellentesque habitant morbi tristique senectus et.

Varius sit amet mattis vulputate. Amet consectetur adipiscing elit ut aliquam purus sit. Eu facilisis sed odio morbi quis commodo odio. Porttitor leo a diam sollicitudin tempor id eu nisl. Quis auctor elit sed vulputate mi sit amet mauris commodo. Arcu felis bibendum ut tristique et egestas quis. Vitae ultricies leo integer malesuada nunc vel risus commodo. Urna condimentum mattis pellentesque id nibh tortor id aliquet lectus. Pretium aenean pharetra magna ac placerat vestibulum lectus. A arcu cursus vitae congue mauris rhoncus aenean vel.

Est ultricies integer quis auctor elit sed. Arcu cursus euismod quis BLUE viverra nibh cras pulvinar. Sit amet consectetur adipiscing elit pellentesque. Mollis aliquam ut porttitor leo a diam sollicitudin tempor. Eu lobortis elementum nibh tellus. Feugiat sed lectus vestibulum mattis. Lacus laoreet non curabitur gravida arcu. Odio ut enim blandit volutpat. Mattis enim ut tellus elementum. Quam lacus suspendisse faucibus interdum posuere lorem ipsum dolor sit. Neque laoreet suspendisse interdum consectetur libero id faucibus nisl. Vel risus commodo viverra maecenas accumsan lacus vel. Phasellus egestas tellus rutrum tellus pellentesque eu tincidunt tortor aliquam. Eleifend donec pretium vulputate sapien nec sagittis aliquam malesuada. Ultricies integer quis auctor elit sed. Odio facilisis mauris sit amet massa vitae. Nunc lobortis mattis aliquam faucibus purus in.

Aenean euismod elementum nisi quis eleifend. At urna condimentum mattis pellentesque. Lectus urna duis convallis convallis. Amet porttitor eget dolor morbi non. Vulputate mi sit amet mauris. Quam id leo in vitae turpis. Massa eget egestas purus viverra accumsan in nisl nisi. Ut sem nulla pharetra diam sit. Dui faucibus in ornare quam viverra orci sagittis eu. Ac turpis egestas sed tempus. Lectus urna duis convallis convallis tellus id. Et malesuada fames ac turpis egestas sed tempus urna. Dictum fusce ut placerat orci nulla pellentesque dignissim enim sit. Nisl pretium fusce id velit ut tortor pretium viverra.

Tempor orci eu lobortis elementum nibh tellus. Ornare massa eget egestas purus viverra accumsan. Vestibulum sed arcu non odio euismod lacinia at quis risus. Ac turpis egestas maecenas pharetra convallis posuere morbi leo. Ac feugiat sed lectus vestibulum mattis ullamcorper velit sed. Tellus in metus vulputate eu scelerisque felis imperdiet. Sit amet purus gravida quis blandit turpis cursus in. Sollicitudin aliquam ultrices sagittis orci. Dui faucibus in ornare quam viverra. In nisl nisi scelerisque eu ultrices. Erat imperdiet sed euismod nisi. Placerat duis ultricies lacus sed turpis. Volutpat maecenas volutpat blandit aliquam. Sit amet mauris commodo quis imperdiet massa tincidunt nunc pulvinar.";

        private const string PostFilterStringWithReplacements =
            @"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. A condimentum vitae sapien pellentesque habitant morbi tristique senectus. Sed arcu non odio euismod lacinia at quis. Nam aliquam sem et tortor consequat id. Donec ac odio tempor orci dapibus ultrices in. Sodales ut eu sem integer vitae justo eget magna fermentum. Facilisi cras fermentum odio eu feugiat. Egestas egestas fringilla phasellus faucibus scelerisque. Viverra tellus in hac habitasse platea dictumst vestibulum. Pulvinar elementum integer enim neque volutpat ac tincidunt. Vel elit scelerisque mauris pellentesque pulvinar pellentesque habitant morbi. Integer eget aliquet nibh praesent. In fermentum et sollicitudin ac. Posuere sollicitudin aliquam ultrices sagittis orci a scelerisque purus semper. Luctus venenatis lectus magna fringilla urna porttitor. Adipiscing elit pellentesque habitant morbi tristique senectus et.

Varius sit amet mattis vulputate. Amet consectetur adipiscing elit ut aliquam purus sit. Eu facilisis sed odio morbi quis commodo odio. Porttitor leo a diam sollicitudin tempor id eu nisl. Quis auctor elit sed vulputate mi sit amet mauris commodo. Arcu felis bibendum ut tristique et egestas quis. Vitae ultricies leo integer malesuada nunc vel risus commodo. Urna condimentum mattis pellentesque id nibh tortor id aliquet lectus. Pretium aenean pharetra magna ac placerat vestibulum lectus. A arcu cursus vitae congue mauris rhoncus aenean vel.

Est ultricies integer quis auctor elit sed. Arcu cursus euismod quis <code>BLUE</code> viverra nibh cras pulvinar. Sit amet consectetur adipiscing elit pellentesque. Mollis aliquam ut porttitor leo a diam sollicitudin tempor. Eu lobortis elementum nibh tellus. Feugiat sed lectus vestibulum mattis. Lacus laoreet non curabitur gravida arcu. Odio ut enim blandit volutpat. Mattis enim ut tellus elementum. Quam lacus suspendisse faucibus interdum posuere lorem ipsum dolor sit. Neque laoreet suspendisse interdum consectetur libero id faucibus nisl. Vel risus commodo viverra maecenas accumsan lacus vel. Phasellus egestas tellus rutrum tellus pellentesque eu tincidunt tortor aliquam. Eleifend donec pretium vulputate sapien nec sagittis aliquam malesuada. Ultricies integer quis auctor elit sed. Odio facilisis mauris sit amet massa vitae. Nunc lobortis mattis aliquam faucibus purus in.

Aenean euismod elementum nisi quis eleifend. At urna condimentum mattis pellentesque. Lectus urna duis convallis convallis. Amet porttitor eget dolor morbi non. Vulputate mi sit amet mauris. Quam id leo in vitae turpis. Massa eget egestas purus viverra accumsan in nisl nisi. Ut sem nulla pharetra diam sit. Dui faucibus in ornare quam viverra orci sagittis eu. Ac turpis egestas sed tempus. Lectus urna duis convallis convallis tellus id. Et malesuada fames ac turpis egestas sed tempus urna. Dictum fusce ut placerat orci nulla pellentesque dignissim enim sit. Nisl pretium fusce id velit ut tortor pretium viverra.

Tempor orci eu lobortis elementum nibh tellus. Ornare massa eget egestas purus viverra accumsan. Vestibulum sed arcu non odio euismod lacinia at quis risus. Ac turpis egestas maecenas pharetra convallis posuere morbi leo. Ac feugiat sed lectus vestibulum mattis ullamcorper velit sed. Tellus in metus vulputate eu scelerisque felis imperdiet. Sit amet purus gravida quis blandit turpis cursus in. Sollicitudin aliquam ultrices sagittis orci. Dui faucibus in ornare quam viverra. In nisl nisi scelerisque eu ultrices. Erat imperdiet sed euismod nisi. Placerat duis ultricies lacus sed turpis. Volutpat maecenas volutpat blandit aliquam. Sit amet mauris commodo quis imperdiet massa tincidunt nunc pulvinar.";
    }
}
