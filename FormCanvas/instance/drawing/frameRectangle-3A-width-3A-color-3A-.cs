frameRectangle: r width: w color: c

	c isTransparent ifFalse: [
		port combinationRule: (self drawRule: Form over).
		port frameRect: (r translateBy: origin)
			borderWidth: w
			borderColor: (self drawColor: c)].
