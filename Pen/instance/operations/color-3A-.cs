color: aColorOrInteger
	"Set the pen to the given color or to a color chosen from a fixed set of colors."

	| count c |
	aColorOrInteger isInteger
		ifTrue: [
			destForm depth = 1 ifTrue: [^ self fillColor: Color black].
			count _ 19.  "number of colors in color wheel"
			c _ (Color red wheel: count) at: ((aColorOrInteger * 7) \\ count) + 1]
		ifFalse: [c _ aColorOrInteger].  "assume aColorOrInteger is a Color"
	self fillColor: c.
