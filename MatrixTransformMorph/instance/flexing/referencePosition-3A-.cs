referencePosition: pos
	self setProperty: #referencePosition toValue: 
		(self transformFromWorld globalPointToLocal: pos)