click: evt

	| col |
	locOfCurrent _ evt cursorPoint - self topLeft.
	locOfCurrent y < 16 ifTrue: [col _ Color transparent]
			ifFalse: [col _ image colorAt: locOfCurrent].
	prevColor _ currentColor.
	currentColor _ col.
	owner class == PaintBoxMorph ifTrue: [
			owner takeColorEvt: evt from: self].
	self invalidRect: (self bounds).