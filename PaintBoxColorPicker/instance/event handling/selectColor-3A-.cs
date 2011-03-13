selectColor: evt
	"Update the receiver from the given event. Constrain locOfCurrent's center to lie within the color selection area. If it is partially in the transparent area, snap it entirely into it vertically."

	| r |
	locOfCurrent _ evt cursorPoint - self topLeft.
	r _ Rectangle center: locOfCurrent extent: 9@9.
	locOfCurrent _ locOfCurrent + (r amountToTranslateWithin: (5@11 corner: 140@136)).
	locOfCurrent x > 128 ifTrue: [locOfCurrent _ 135@locOfCurrent y].  "snap into grayscale"
	locOfCurrent y < 17
		ifTrue: [
			locOfCurrent _ locOfCurrent x@11.  "snap into transparent"
			currentColor _ Color transparent]
		ifFalse: [
			currentColor _ image colorAt: locOfCurrent].

	(owner isKindOf: PaintBoxMorph) ifTrue: [owner takeColorEvt: evt from: self].

	self changed.
