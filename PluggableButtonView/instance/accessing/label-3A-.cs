label: aStringOrDisplayObject 
	"Label this button with the given String or DisplayObject."

	((aStringOrDisplayObject isKindOf: Paragraph)
	or: [aStringOrDisplayObject isForm])
		ifTrue: [label _ aStringOrDisplayObject]
		ifFalse: [label _ aStringOrDisplayObject asParagraph].
	self centerLabel.
