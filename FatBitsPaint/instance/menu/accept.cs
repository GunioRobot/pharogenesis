accept

	| f |
	f _ (self form shrink: self form boundingBox by: magnification).
	((f boundingBox = formToEdit boundingBox) and: [f depth = formToEdit depth])
		ifFalse: [^ self error: 'implementation error; form dimensions and depth should match'].
	formToEdit bits: f bits.  "modify formToEdit in place"
