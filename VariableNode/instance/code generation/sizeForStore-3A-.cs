sizeForStore: encoder
	self reserve: encoder.
	code < 256 ifTrue: [^ 2].
	(code \\ 256) <= 63 ifTrue: [^ 2].
	^ 3