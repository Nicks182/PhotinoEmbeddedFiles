# PhotinoEmbeddedFiles

Using [Photino.io ](https://www.tryphotino.io/)  allows us to create cross platform desktop applications using HTML, javascript, and CSS with C# as your backend.

This little project shows how to embed the html, script, css, and other asset files so you can produce a single exe. This way your assets won't be easily accessible inside the application directory and users can’t edit them.

### See how to embed fiels using file server:
https://github.com/Nicks182/PhotinoStaticFileServer

### Official Photino Samples

https://github.com/tryphotino/photino.Samples

## The How
### 1. Create a new project

Start by creating a new simple Console Application. I’m using DotNet 8.0, but you can use 7.0 if you prefer. I also ticked the “Do not use top-level statements” under Additional Information, but you don’t have to.

![image](https://github.com/Nicks182/PhotinoEmbeddedFiles/assets/13113785/d24c7589-ad7f-4775-b219-29941f825c3d)

### 2. Add the Photino.Net nuget package

![image](https://github.com/Nicks182/PhotinoEmbeddedFiles/assets/13113785/96385c39-9dbe-4a6d-989c-01625d86d46d)

### 3. Embedding files

Start by creating an Assets folder and add your own files or use the ones in this repository.

You can manually embed any file by right clicking the file and editing its properties. I normally add a wild card to my project file. Here’s how.

Right click the project file and go to Edit Project File:

![image](https://github.com/Nicks182/PhotinoEmbeddedFiles/assets/13113785/241c5fe4-2e71-45b1-931e-5c97da7b6105)

Add the highlighted part like in the image below. You can name your folder something other than Assets. Now anything you place in that directory will be Embedded into the exe automatically and you don’t have to do it with each file you wish to add.

Also set the OutputType to WinExe so we don’t get a console window.

![image](https://github.com/Nicks182/PhotinoEmbeddedFiles/assets/13113785/b071e989-e27c-48fb-b206-fee82e23d52a)

### 4. Some code to read our embedded files.

Pay attention to the ‘FileDomain’ variable.

“PhotinoEmbeddedFiles” is the namespace of the application.

“Assets” is the folder containing the files.

You can structure this Assets folder how you like, just remember to ensure that everything you want to be Embedded is marked as such. Update the project file as needed.

![image](https://github.com/Nicks182/PhotinoEmbeddedFiles/assets/13113785/5cd4dc39-81d0-4e6c-9d0e-beec546eb6fa)

### 5. RegisterCustomSchemeHandler

Now we need to register a Custom Scheme Handler for our script file and our style file. In short, our HTML file can’t read our embedded files directly. We need a handler to find the right resource and return it to our page.

![image](https://github.com/Nicks182/PhotinoEmbeddedFiles/assets/13113785/f74d9127-46a9-4415-bcd0-62ff8fb1c8be)

### 6. Get html file

We also need to read our index.html file and pass it as a string to our photino window.

![image](https://github.com/Nicks182/PhotinoEmbeddedFiles/assets/13113785/298a0540-cc1b-4b3a-99bd-b6dfe77526ca)

Full Program class:

![image](https://github.com/Nicks182/PhotinoEmbeddedFiles/assets/13113785/06b9723b-4a9f-42f9-8196-92fda3a9ea87)

### 7. Style and Script tags

Lastly, we need to add our style and script file to our html page like below. Note the : is important for our handlers to work.

![image](https://github.com/Nicks182/PhotinoEmbeddedFiles/assets/13113785/0a45bd2f-3051-4875-98d8-c5a41aeaaaa9)

### NOTE: “mycss:” and “myjs:” is how our handlers will know when to respond.

![image](https://github.com/Nicks182/PhotinoEmbeddedFiles/assets/13113785/5c67471d-aeab-4139-ae3d-6d5363ef7c30)

### 8. Test it

The app should run now if you hit F5 in Visual Studio. When the window first opens it will show an alert. Close the alert and click the button to send a message to the C# code. The C# code will just send the message straight back and you will see another alert.


### 9. Publish it

Right click the project and select Publish. 

![image](https://github.com/Nicks182/PhotinoEmbeddedFiles/assets/13113785/3727f767-4e6a-42a1-89b2-dbf75c0057d1)

A new window will open up. Select Folder, click Next, select Folder again, click Next again. Now click the Browse button and choose where you would like to publish the files. Click Finish, then Close. You should see the below image…

![image](https://github.com/Nicks182/PhotinoEmbeddedFiles/assets/13113785/a8d611e4-3ace-401b-9394-d3094313761e)

Now click Show all settings and copy the image below. 

Deployment mode = Self-contained. This means you won’t need to install .net on the system you want to run the app on as it will contain all it needs to do so on it’s own.

Target Runtime = win-x64. This needs to match the OS you wish to run the app on. I’m on Windows 10 x64 so I need to select win-x64.

Produce single file = true. So we create a single exe file.

Trim unused code is optional.

![image](https://github.com/Nicks182/PhotinoEmbeddedFiles/assets/13113785/164e2231-4f51-4181-95ff-d945704c7800)

Click save and then click the big Publish button at the top of the screen. Once done you should see the following 4 files in your publish folder.

![image](https://github.com/Nicks182/PhotinoEmbeddedFiles/assets/13113785/d07b570c-6f8d-4e88-abf6-74443b7256e1)

Yes… it’s not really a single file. Depending on the dll, it can’t always be put into a single file. In this case I believe it’s because they are C++. The .pdb file is not needed to run the app though.

Double click the exe to run the app.

## Additional info
I often end up having a lot of small individual script and style files which I end up bundling together.

To bundle your files you can use something like: [BundlerMinifier](https://github.com/madskristensen/BundlerMinifier)

I’m currently using a more up to date version: [BundlerMinifierPlus](https://github.com/salarcode/BundlerMinifierPlus)
