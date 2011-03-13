spawnIt: characterStream 
	"Triggered by Cmd-o; spawn a new code window, if it makes sense.  Reimplemented by BrowserCodeController  2/1/96 sw"

	sensor keyboard.		"flush character"
	view flash.
	^ true