makeUppercase: characterStream 
	"Force the current selection to uppercase.  Triggered by Cmd-Y."

	sensor keyboard.		"flush the triggering cmd-key character"
	self replaceSelectionWith: (Text fromString: (self selection string asUppercase)).
	^ true