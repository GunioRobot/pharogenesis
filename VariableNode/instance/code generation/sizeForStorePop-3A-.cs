sizeForStorePop: encoder
	self reserve: encoder.
	(code < 24 and: [code noMask: 8]) ifTrue: [^ 1].
	code < 256 ifTrue: [^ 2].
	code \\ 256 <= 63 ifTrue: [^ 2].  "extended StorePop"
	code // 256 = 1 ifTrue: [^ 3].  "dbl extended StorePopInst"
	code // 256 = 4 ifTrue: [^ 4].  "dbl extended StoreLitVar , Pop"
	self halt.  "Shouldn't get here"