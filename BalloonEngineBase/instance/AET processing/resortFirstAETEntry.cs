resortFirstAETEntry
	| edge xValue leftEdge |
	self inline: false.
	self aetStartGet = 0 ifTrue:[^nil]. "Nothing to resort"
	edge _ aetBuffer at: self aetStartGet.
	xValue _ self edgeXValueOf: edge.
	leftEdge _ aetBuffer at: (self aetStartGet - 1).
	(self edgeXValueOf: leftEdge) <= xValue ifTrue:[^nil]. "Okay"
	self moveAETEntryFrom: self aetStartGet edge: edge x: xValue.