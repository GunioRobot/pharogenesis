frameAndFillRectangle: r fillColor: fillColor borderWidth: borderWidth borderColor: borderColor

	| outerRect |
	port combinationRule: (self drawRule: Form over).
	outerRect _ r translateBy: origin.
	borderColor isTransparent ifFalse: [
		"draw border of rectangle"
		(r area > 10000 or: [fillColor isTransparent]) ifTrue: [
			port frameRect: outerRect
				borderWidth: borderWidth
				borderColor: (self drawColor: borderColor).
		] ifFalse: [
			"for small rectangles, it's faster to paint the whole outerRect
			 than to compute and fill the border rects"
			port fillRect: outerRect color: (self drawColor: borderColor) offset: origin]].

	"fill inside of rectangle"
	fillColor isTransparent ifFalse: [
		port fillRect: (outerRect insetBy: borderWidth)
			 color: (self drawColor: fillColor)
			 offset: origin].
