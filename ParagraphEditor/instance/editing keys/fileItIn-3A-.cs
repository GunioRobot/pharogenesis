fileItIn: characterStream 
	"File in the selection; invoked via a keyboard shortcut, -- for now, cmd-shift-G."

	sensor keyboard.		"flush character"
	self terminateAndInitializeAround: [self fileItIn].
	^ true