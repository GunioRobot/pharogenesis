openEditing
	openForEditing _ true.
	self color: Color green.
	book pages do:
		[:aPage | aPage setPartsBinStatusTo: false]