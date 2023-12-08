# PhotinoEmbeddedFiles

Using [Photino.io ](https://www.tryphotino.io/)  allows us to create cross platform desktop applications using HTML, javascript, and CSS with C# as your backend.

This little project shows how to embed the html, script, css, and other asset files so you can produce a single exe. This way your assets won't be easily accessible inside the application directory and users can’t edit them.

## The How
### 1. Create a new project

Start by creating a new simple Console Application. I’m using DotNet 8.0, but you can use 7.0 if you prefer. I also ticked the “Do not use top-level statements” under Additional Information, but you don’t have to.

![image](https://github.com/Nicks182/PhotinoEmbeddedFiles/assets/13113785/d24c7589-ad7f-4775-b219-29941f825c3d)

### 2. Add the Photino.Net nuget package

![image](https://github.com/Nicks182/PhotinoEmbeddedFiles/assets/13113785/96385c39-9dbe-4a6d-989c-01625d86d46d)

### 3. Embedding files

You can manually embed any file by right clicking the file and editing its properties. I normally add a wild card to my project file. Here’s how.

Right click the project file and go to Edit Project File:

![image](https://github.com/Nicks182/PhotinoEmbeddedFiles/assets/13113785/241c5fe4-2e71-45b1-931e-5c97da7b6105)

Add the highlighted part like in the image below. You can name your folder something other than Assets. Now anything you place in that directory will be Embedded into the exe automatically and you don’t have to do it with each file you wish to add.

![image](https://github.com/Nicks182/PhotinoEmbeddedFiles/assets/13113785/fdaf1eb6-cdb3-4031-bccb-01dd9669d142)

### 4. Some code to read our embedded files.

Pay attention to the ‘FileDomain’ variable.

“PhotinoEmbeddedFiles” is the namespace of the application.

“Assets” is the folder containing the files.

You can structure this Assets folder how you like, just remember to ensure that everything you want to be Embedded is marked as such. Update the project file as needed.

![image](https://github.com/Nicks182/PhotinoEmbeddedFiles/assets/13113785/5cd4dc39-81d0-4e6c-9d0e-beec546eb6fa)

### 5. RegisterCustomSchemeHandler

Now we need to register a Custom Scheme Handler for our script file and our style file. In short, our HTML file can’t read our embedded files directly. We need a handler to find the right resource and return it to our page.

![image](https://github.com/Nicks182/PhotinoEmbeddedFiles/assets/13113785/75667a5c-4f0f-4521-aa2f-2803c58e0ac4)

### 6. Get html file

We also need to read our index.html file and pass it as a string to our photino window.

![image](https://github.com/Nicks182/PhotinoEmbeddedFiles/assets/13113785/50ac7127-cae4-4735-86be-4041e22fa5f8)

Full Program class:

![image](https://github.com/Nicks182/PhotinoEmbeddedFiles/assets/13113785/943a6ca2-b3a0-4e8e-a7e7-9de24a608738)

### 7. CSS and Script tags

Lastly, we need to add our style and script file to our html page like below. Note the : is important for our handlers to work.

![image](https://github.com/Nicks182/PhotinoEmbeddedFiles/assets/13113785/d1d5426d-6e4a-42b4-86c4-97299ff39c6a)

## Additional info
I often end up having a lot of small individual script and style files which I end up bundling together.

To bundle your files you can use something like: [BundlerMinifier](https://github.com/madskristensen/BundlerMinifier)

I’m currently using a more up to date version: [BundlerMinifierPlus](https://github.com/salarcode/BundlerMinifierPlus)
