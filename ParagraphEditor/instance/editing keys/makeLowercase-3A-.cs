makeLowercase: characterStream 
	"Force the current selection to lowercase.  Triggered by Cmd-X."

	sensor keyboard.		"flush the triggering cmd-key character"
	self replaceSelectionWith: (Text fromString: (self selection string asLowercase)).
	^ true