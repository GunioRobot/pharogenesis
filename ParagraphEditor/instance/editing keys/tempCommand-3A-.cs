tempCommand: characterStream 
	"Experimental.  Triggered by Cmd-t; put trial cmd-key commands here to see how they work, before hanging them on their own cmd accelerators."

	sensor keyboard.		"flush the triggering cmd-key character"
	self experimentalCommand.
	^ true