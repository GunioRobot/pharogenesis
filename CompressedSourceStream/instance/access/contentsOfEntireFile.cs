contentsOfEntireFile
	| contents |
	self position: 0.
	contents _ self next: self size.
	self close.
	^ contents