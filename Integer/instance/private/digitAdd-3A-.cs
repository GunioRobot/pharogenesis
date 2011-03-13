digitAdd: arg
	| len arglen accum sum |
	accum _ 0.
	(len _ self digitLength) < (arglen _ arg digitLength)
		ifTrue: [len _ arglen].
	"Open code max: for speed"
	sum _ Integer new: len neg: self negative.
	1 to: len do: 
		[:i |
		accum _ (accum bitShift: -8) + (self digitAt: i) + (arg digitAt: i).
		sum digitAt: i put: (accum bitAnd: 255)].
	accum > 255 ifTrue: 
			[sum _ sum growby: 1.
			sum at: sum digitLength put: (accum bitShift: -8)].
	^sum