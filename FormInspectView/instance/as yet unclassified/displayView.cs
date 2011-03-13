displayView 
	"Display the form as a value in an inspector.  8/11/96 sw"
	"Defeated form scaling for HS FormInspector.  8/20/96 di"
	| scale |
	Display fill: self insetDisplayBox fillColor: Color white.
	model selectionIndex == 0 ifTrue: [^ self].
	scale := self insetDisplayBox extent / model selection extent.
	scale := (scale x min: scale y) min: 1.
	model selection
		displayOn: Display
		transformation: (WindowingTransformation
			scale: scale asPoint
			translation: self insetDisplayBox topLeft - model selection offset)
		clippingBox: self insetDisplayBox
		rule: self rule
		fillColor: self fillColor