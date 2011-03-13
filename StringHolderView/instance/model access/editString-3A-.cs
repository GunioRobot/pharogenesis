editString: aString 
	"The paragraph to be displayed is created from the characters in aString."

	displayContents _ Paragraph withText: aString asText
		style: TextStyle default copy
		compositionRectangle: (self insetDisplayBox insetBy: 6 @ 0)
		clippingRectangle: self insetDisplayBox
		foreColor: self foregroundColor backColor: self backgroundColor.
	(self controller isKindOf: ParagraphEditor)
		ifTrue: [controller changeParagraph: displayContents]