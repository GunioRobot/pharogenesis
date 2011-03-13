nextPartsBank
	partsBank _ self partsBank + 1.
	partsBank > self maxPartsBankNumber ifTrue: [partsBank _ 1].
	self presenter updatePartsViewer: self