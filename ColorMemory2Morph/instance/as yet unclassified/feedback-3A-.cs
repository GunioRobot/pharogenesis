feedback: evt

	| col loc |
	loc _ evt cursorPoint - self topLeft.
	loc y < 16 ifTrue: [col _ Color transparent]
			ifFalse: [col _ image colorAt: loc].
	Display fill: (owner colorPatch bounds translateBy: self world viewBox origin) 
			fillColor: col.
