displayOn: aDisplayMedium transformation: displayTransformation clippingBox: clipRectangle align: alignmentPoint with: relativePoint rule: ruleInteger fillColor: aForm 
	"Copied from Form, basically"
	| absolutePoint scale magnifiedForm |
	absolutePoint _ displayTransformation applyTo: relativePoint.
	absolutePoint _ absolutePoint x asInteger @ absolutePoint y asInteger.
	displayTransformation noScale
		ifTrue: [magnifiedForm _ self]
		ifFalse: 
			[scale _ displayTransformation scale.
			scale _ scale x rounded @ scale y rounded.
			(1@1 = scale)
					ifTrue: [scale _ nil. magnifiedForm _ self]
					ifFalse: [magnifiedForm _ self magnify: self boundingBox by: scale]].
	magnifiedForm
		displayOn: aDisplayMedium
		at: absolutePoint - alignmentPoint
		clippingBox: clipRectangle
		rule: ruleInteger
		fillColor: aForm