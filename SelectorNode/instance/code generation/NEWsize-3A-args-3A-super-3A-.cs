NEWsize: encoder args: nArgs super: supered
	"This can be enabled when bytecode 134 has been redefined
	to be medium length send up to 64 lits"
	| index |
	self reserve: encoder.
	(supered not and: [code - Send < SendLimit and: [nArgs < 3]])
		ifTrue: [^1]. "short send"
	(supered and: [code < Send]) ifTrue: 
		["super special:"
		code _ self code: (encoder litIndex: key) type: 5].
	index _ code < 256
				ifTrue: [code - Send]
				ifFalse: [code \\ 256].
	(index <= 31 and: [nArgs <= 7])
		ifTrue: [^ 2]. "medium send"
	(supered not and: [index <= 63 and: [nArgs <= 3]])
		ifTrue: [^ 2]. "new medium send"
	^ 3 "long send"