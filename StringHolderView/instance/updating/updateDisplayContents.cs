updateDisplayContents
	"Make the text that is displayed be the contents of the receiver's model."

	self editString: model contents.
	self displayView