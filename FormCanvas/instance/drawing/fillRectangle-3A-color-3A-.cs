fillRectangle: r color: c

	c isTransparent ifFalse: [
		port combinationRule: (self drawRule: Form over).
		port fillRect: (r translateBy: origin) color: (self drawColor: c) offset: origin].
