using PhotinoNET;
using System.Reflection;

namespace PhotinoEmbeddedFiles
{
    /*
     * Note the changes in the project file...
        <ItemGroup>
		    <EmbeddedResource Include="Assets\**\*" />
	    </ItemGroup>
     */

    internal class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            PhotinoWindow Win = new PhotinoWindow()
                .RegisterCustomSchemeHandler("mycss", (object sender, string scheme, string url, out string contentType) =>
                {
                    contentType = "text/css";
                    return _GetFileStream("style.css");
                })
                .RegisterCustomSchemeHandler("myjs", (object sender, string scheme, string url, out string contentType) =>
                {
                    contentType = "text/javascript";
                    return _GetFileStream("script.js");
                })

                .RegisterWindowCreatedHandler(Win_WindowCreated)
                .LoadRawString(_GetFileString("index.html"));

            Win.WaitForClose();

        }

        private static void Win_WindowCreated(object? sender, EventArgs e)
        {
            // Using this event seems to be the only way to get Maximized to work
            // Trying to set it before the window is created seems to not work...
            (sender as PhotinoWindow).SetMaximized(true);
        }

        const string FileDomain = "PhotinoEmbeddedFiles.Assets.";
        private static string _GetFileString(string filename)
        {
            var sr = new StreamReader(_GetFileStream(filename));

            return sr.ReadToEnd();
        }

        private static Stream _GetFileStream(string filename)
        {
            var asm = Assembly.GetExecutingAssembly();

            return asm.GetManifestResourceStream(FileDomain + filename);

        }

    }
}
