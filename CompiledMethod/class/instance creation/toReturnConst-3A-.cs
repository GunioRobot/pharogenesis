toReturnConst: constCode
	"Answer an instance of me that is a quick return of a constant
	constCode = 1...7  ->  true, false, nil, -1, 0, 1, 2."

	^ self newBytes: 0 nArgs: 0 nTemps: 0 nStack: 0 nLits: 0 primitive: 256 + constCode