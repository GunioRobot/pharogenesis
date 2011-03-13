mouseEnteredDZ

	| dz |
	dz _ self valueOfProperty: #specialDropZone ifAbsent: [^self].
	dz color: Color blue.