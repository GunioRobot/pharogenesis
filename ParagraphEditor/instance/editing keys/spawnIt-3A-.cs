spawnIt: characterStream 
	"Triggered by Cmd-o; spawn a new code window, if it makes sense."

	self controlTerminate.
	sensor keyboard.
	self spawn.
	self controlInitialize.
	^ true