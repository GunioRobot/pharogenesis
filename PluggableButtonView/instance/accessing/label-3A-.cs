label: aStringOrDisplayObject 
	"Label this button with the given String or DisplayObject."

	((aStringOrDisplayObject isKindOf: Paragraph)
	or: [aStringOrDisplayObject isForm])
		ifTrue: [label := aStringOrDisplayObject]
		ifFalse: [label := aStringOrDisplayObject asParagraph].
	self centerLabel.
