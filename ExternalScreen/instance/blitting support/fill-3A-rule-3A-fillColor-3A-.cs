fill: aRectangle rule: anInteger fillColor: aColor 
	"Replace a rectangular area of the receiver with the pattern described by aForm 
	according to the rule anInteger."
	| rect |
	(self isFillAccelerated: anInteger for: aColor) ifTrue:[
		rect _ aRectangle intersect: clippingBox.
		(self primFill: bits
			color: (self pixelWordFor: aColor)
			x: rect left
			y: rect top
			w: rect width
			h: rect height) ifNotNil:[^self]].
	^super fill: aRectangle rule: anInteger fillColor: aColor