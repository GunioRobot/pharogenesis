makeUppercase: characterStream 
	"Force the current selection to uppercase.  Triggered by Cmd-Y."

	self replaceSelectionWith: (Text fromString: (self selection string asUppercase)).
	^ true