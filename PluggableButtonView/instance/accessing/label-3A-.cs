label: aStringOrDisplayObject 
	"Label this button with the given String or DisplayObject."

	(aStringOrDisplayObject isKindOf: String)
		ifTrue: [label _ aStringOrDisplayObject asParagraph]
		ifFalse: [label _ aStringOrDisplayObject].
	self centerLabel.
