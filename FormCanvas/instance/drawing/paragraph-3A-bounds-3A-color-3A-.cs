paragraph: para bounds: bounds color: c

	| paraCopy |
	paraCopy _ para copy.  "Because displayOn:at: bashes a para's rectangles"
	paraCopy
		foregroundColor: (shadowDrawing ifTrue: [Color black] ifFalse: [c])
		backgroundColor: Color transparent.
	paraCopy displayOn: form
		at: (bounds topLeft + origin)
		clippingBox: (clipRect intersect: (bounds translateBy: origin))
		rule: (self drawRule: Form paint)
		fillColor: (shadowDrawing
					ifTrue: [self drawColor: c]
					ifFalse: [nil])