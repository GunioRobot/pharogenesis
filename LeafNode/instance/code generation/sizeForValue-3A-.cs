sizeForValue: encoder
	self reserve: encoder.
	self code < 256 ifTrue: [^ 1].
	(self code \\ 256) <= 63 ifTrue: [^ 2].
	^ 3