closeEditing
	openForEditing _ false.
	self color: Color white.
	book pages do:
		[:aPage | aPage setPartsBinStatusTo: true]