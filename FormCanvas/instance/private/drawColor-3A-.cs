drawColor: aColor

	^ shadowDrawing
		ifTrue: [shadowStipple]
		ifFalse: [aColor]