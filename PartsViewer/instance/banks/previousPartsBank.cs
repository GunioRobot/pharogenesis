previousPartsBank
	partsBank _ self partsBank - 1.
	partsBank < 1 ifTrue: [partsBank _ self maxPartsBankNumber].
	self presenter updatePartsViewer: self