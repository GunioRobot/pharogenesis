pasteInitials: characterStream 
	"Replace the current text selection by an authorship name/date stamp; invoked by cmd-shift-v, easy way to put an authorship stamp in the comments of an editor.
	 Keeps typeahead."

	sensor keyboard.		"flush character"
	self closeTypeIn: characterStream.
	self replace: self selectionInterval with: (Text fromString: Utilities changeStamp) and: [self selectAt: self stopIndex].
	^ true