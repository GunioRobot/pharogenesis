newParagraph: para bounds: bounds color: c
	| scanner |
	scanner _ port displayScannerFor: para
		foreground: (self drawColor: c)
		background: Color transparent
		rule: (self drawRule: Form paint)
		halftone: (shadowDrawing ifTrue: [self drawColor: c] ifFalse: [nil]).
	para displayOn: self using: scanner at: (bounds topLeft + origin)
