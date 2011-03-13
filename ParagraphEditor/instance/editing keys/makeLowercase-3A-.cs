makeLowercase: characterStream 
	"Force the current selection to lowercase.  Triggered by Cmd-X."

	self replaceSelectionWith: (Text fromString: (self selection string asLowercase)).
	^ true