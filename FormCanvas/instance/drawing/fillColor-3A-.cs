fillColor: c
	"Note: This always fills, even if the color is transparent."

	port combinationRule: Form over.
	port fillRect: form boundingBox color: (self drawColor: c) offset: origin.
