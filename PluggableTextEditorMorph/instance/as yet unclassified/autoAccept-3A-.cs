autoAccept: aBoolean
	"Set whether the editor accepts its contents on each change.
	Only takes effect after the text is set."

	self setProperty: #autoAccept toValue: aBoolean.
	self textMorph ifNotNilDo: [:t | t autoAccept: aBoolean]