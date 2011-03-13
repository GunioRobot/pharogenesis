spawnIt: characterStream 
	"Triggered by Cmd-o; spawn a new code window, if it makes sense.  Reimplemented by BrowserCodeController  2/1/96 sw.  Fixed, 2/5/96 sw, so that it really works."

	self controlTerminate.
	sensor keyboard.	
	self spawn.
	self controlInitialize.
	^ true