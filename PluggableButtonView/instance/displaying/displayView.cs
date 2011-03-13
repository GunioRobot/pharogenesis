displayView
	"Displays this switch and its label, if any."

	self clearInside.
	label ifNotNil: [
		(label isKindOf: Paragraph) ifTrue: [
			label foregroundColor: self foregroundColor
				 backgroundColor: self backgroundColor].
		label displayOn: Display
			transformation: self displayTransformation
			clippingBox: self insetDisplayBox
			fixedPoint: label boundingBox center].
	complemented _ false.
