invertRect: aRectangle
	"Return a rectangle whose coordinates have been transformed
	from local back to global coordinates.  NOTE: if the transformation
	is not just a translation, then it will compute the bounding box
	in global coordinates."
	| outerRect |
	self isPureTranslation
	ifTrue:
		[^ (self invert: aRectangle topLeft)
			corner: (self invert: aRectangle bottomRight)]
	ifFalse:
		[outerRect _ Rectangle encompassing:
			(aRectangle innerCorners collect: [:p | self invert: p]).
		^ outerRect topLeft corner: outerRect bottomRight + (1@1)]