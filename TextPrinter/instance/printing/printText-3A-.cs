printText: aText
	"Print aText"
	form isNil ifTrue:[
		form := Form extent: self pixelSize depth: depth.
	].
	para := Paragraph withText: aText asText.
	Cursor wait showWhile:[
		self printParagraph.
	].