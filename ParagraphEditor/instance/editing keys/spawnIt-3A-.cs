spawnIt: characterStream
	"Triggered by Cmd-o; spawn a new code window, if it makes sense."

	sensor keyboard.
	self terminateAndInitializeAround: [self spawn].
	^ true