displayView
	"Does the standard View actions and, in addition, displays the receiver's 
	label based on the current display transformation and inset display box."

	highlightForm == nil ifFalse: [self displaySpecial].
	self clearInside.
	label == nil
		ifFalse: 
			[(label isKindOf: Paragraph) ifTrue:
					[label foregroundColor: self foregroundColor
					 backgroundColor: self backgroundColor].
			label displayOn: Display
				transformation: self displayTransformation
				clippingBox: self insetDisplayBox
				fixedPoint: label boundingBox center].
	complemented _ false