FaceCopy v1.42 by Admiral H. Curtiss
Feel free to edit and redistribute


FaceCopy is a helper tool for Screenshot Let's Plays. If you're working with lots of character mugshots (or other recurring images), it can help you organize and retrieve them. This is especially useful if you have several different expressions for a single character, which can't be easily put into the LP update with a Find-and-Replace. FaceCopy shows you all mugshots at once, and you can simply click on one to copy it to the clipboard, ready to be pasted into the update next to the appropriate line.


Usage:
Fairly simple, just add categories with the Add Category button and images with the Add Image button, then provide name, file or URL when asked. Note that you cannot directly add images to the "All" category, which contains the images from all other categories combined.
The Open and Save buttons open and save the current image set as an XML file.
Once an image is added, you can simply click on it to copy its URL including [img]-tags to your clipboard, ready to be pasted into an LP update or whatever.


Version History:
1.42
- Images now blink blue when copying the URL, to give feedback about it registering your click.

1.41
- Controls now focus properly when changing tab, which means mouse wheel scrolling should work now.

1.4
- Added ability to add via URL only, useful for simply copy-pasting the output from Rightload.

1.3
- A name can now be given to each image (right click -> Edit Name). By using the "Replace in Update" button, you can open a text file (ie, an LP update) and it will automatically replace all names found in there with the appropriate image URL. For example, if you write an update and use image placeholders such as:

        [yuri-smug] It'll be over a hundred years before you can beat me!
        [estelle-curious] Because you've lived a lot longer, right?
        [yuri-doubt-ec] ...Not exactly.

  Just name your images "[yuri-smug]", "[estelle-curious]", and "[yuri-doubt-ec]" respectively, and the "Replace in Update" button turns the above into this:

      [img]http://lpix.org/241768/Yuri_smug.jpg[/img] It'll be over a hundred years before you can beat me!
      [img]http://lpix.org/242167/Estelle_curious.jpg[/img] Because you've lived a lot longer, right?
      [img]http://lpix.org/237201/Yuri_doubt_eyesclosed.jpg[/img] ...Not exactly.

- Sometimes a newly added image did not appear in the "All" category, a workaround was to just save and reopen the image set and it'll appear fine. I *think* I fixed this but I'm not entirely sure.
- Downloaded images now have their SHA1 prepended to their filename to prevent accidental overwrites.

1.2
- An image may now have multiple paths, when opening image files each path is checked in order until one valid one is found. Any paths beyond the first must be manually added to the XML or get automatically added by server download. Images downloaded because they could not be found now append their path to the existing one(s) rather than overwriting it. This is useful if you want to use one and the same XML on multiple computers.

1.1
- You can now right-click on an image to delete it or edit the URL that gets copied when you click on it.
- If an image cannot be found or opened from the file path in the XML, it will now be downloaded from the URL. This might take a bit so be patient. Downloaded images are stored in your Windows User's My Pictures folder (in a FaceCopy subfolder).

1.0
- First Release
