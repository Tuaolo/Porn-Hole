# Porn Hole

Porn Hole is just an image slide show, intended to be displayed at large or small group gatherings where that might be appropriate.

We used to use TumbView for it. Then Tumblr nixed adult content.

I went looking for a desktop app with 4 simple criteria:
  1) Let me specify a directory (or tree) as a source for the images to display
  2) Let me display them in randomized order
  3) Let me set an interval for how often to rotate through them
  4) Let me view them at full screen (generally to be cast to a TV)

You'd think that would be very basic and there'd be at least half a dozen options to choose from...

Turns out you can really only find things that cover some combination of 2 of those 4. I think I found one that did 3 of them.

So...I wrote one.

Just so I can have a reliable slideshow of porn.

Or not porn, as appropriate.

But really just porn.

I am fully aware that--on top of being completely amateur in design--there are a number of coding atrocities herein. I am services programmer by trade. I know just enough about desktop app coding to get myself into trouble. As you can see.

I apologize for nothing. This does what I need it to do. 

Anyway, this is v1.1, which addressed some things beyond those initial 4 requirements.
  * An assortment of fatal bug fixes.
  * Opens the full screen view on the same screen as the controller.
  * Added some manual forward and back navigation.

Possible Enhancements:
  * Make a proper back-end and separate it from the UI (in progress)
  * Upgrade directory picker to allow picking multiple directories
  * Look at upgrading whole project to a newer format (WPF?)
  * Clean up full-screen controls, 'cause they be ugly
  * Let's be honest, the main controller could look 100x better, too
  * Ability to pick which screen full-screen appears on
  * Allow different sorts (by date, by filename, don't re-randomize with every new loop through the files, "true" random (where you don't loop the files at all))
  * Ability to share the current image to email/Twitter/Telegram/whatever.
    * A half-way point to this may be the ability to show the file name/location or even open the containing directory with the file selected.
