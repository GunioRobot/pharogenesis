sizeForStorePop: encoder
	self reserve: encoder.
	(self code < 24 and: [self code noMask: 8]) ifTrue: [^ 1].
	self code < 256 ifTrue: [^ 2].
	self code \\ 256 <= 63 ifTrue: [^ 2].  "extended StorePop"
	self code // 256 = 1 ifTrue: [^ 3].  "dbl extended StorePopInst"
	self code // 256 = 4 ifTrue: [^ 4].  "dbl extended StoreLitVar , Pop"
	self halt.  "Shouldn't get here"