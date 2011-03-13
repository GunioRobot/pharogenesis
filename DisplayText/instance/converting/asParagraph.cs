asParagraph
	"Answer a Paragraph whose text and style are identical to that of the 
	receiver."
	| para |
	para := Paragraph withText: text style: textStyle.
	para foregroundColor: foreColor backgroundColor: backColor.
	backColor isTransparent ifTrue: [para rule: Form paint].
	^ para