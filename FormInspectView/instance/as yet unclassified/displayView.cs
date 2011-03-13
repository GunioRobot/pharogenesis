displayView 
	"Display the form as a value in an inspector.  8/11/96 sw"
	"Defeated form scaling for HS FormInspector.  8/20/96 di"
	| oldOffset |
	Display fill: self insetDisplayBox fillColor: Color white.
	model selectionIndex == 0 ifTrue: [^ self].
	oldOffset _ model selection offset.
	offset == nil ifFalse: [model selection offset: offset asPoint].
	model selection
		displayOn: Display
		transformation: (WindowingTransformation
			scale: 1@1
			translation: self displayTransformation translation)
		clippingBox: self insetDisplayBox
		rule: self rule
		fillColor: self fillColor.
	model selection offset: oldOffset