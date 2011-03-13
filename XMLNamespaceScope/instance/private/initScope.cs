initScope
	scope := OrderedCollection new: 20.
	currentBindings := Dictionary new.
	scope addLast: {'http://www.w3.org/TR/REC-xml-names'. currentBindings. nil. }.
