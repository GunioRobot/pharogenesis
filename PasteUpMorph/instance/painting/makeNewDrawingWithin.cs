makeNewDrawingWithin
	| evt |
	evt _ MouseEvent new setType: nil position: self center buttons: 0 hand: self world activeHand.
	self primaryHand makeNewDrawing: evt
