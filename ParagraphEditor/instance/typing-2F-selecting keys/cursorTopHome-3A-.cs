cursorTopHome: characterStream 
	"Put cursor at beginning of text -- invoked from cmd-H shortcut, useful for keyboards that have no home key."
	
	sensor keyboard.
	self selectAt: 1.
	^ true