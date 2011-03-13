fileItIn: characterStream 
	"File in the selection; invoked via a keyboard shortcut, -- for now, cmd-shift-G."

	self terminateAndInitializeAround: [self fileItIn].
	^ true