roll: diceString
	"Roll some dice, DnD-style, according to this mini-grammar:
		dice _ epxr {pm expr}
		pm _ '+' | '-'
		expr _ num | num dD | dD numP | num dD numP
		dD _ 'd' | 'D'
		num _ digit+
		numP _ num | '%'"

	| stream op result dice range res token |
	stream _ diceString readStream.
	result _ 0.
	op _ #+.
	[token _ self diceToken: stream.
	token isNumber
		ifTrue: [dice _ token.
				token _ self diceToken: stream]
		ifFalse: [token == $d
			ifTrue: [dice _ 1]
			ifFalse: [res _ 0]].
	token == $d
		ifTrue: [token _ self diceToken: stream.
				token isNumber
					ifTrue: [range _ token.
							token _ self diceToken: stream]
					ifFalse: [token == $%
						ifTrue: [range _ 100.
								token _ self diceToken: stream]
						ifFalse: [range _ 6]].
				res _ 0.
				dice timesRepeat: [res _ res + (self nextInt: range)]].
	result _ result perform: op with: res.
	token ifNil: [^ result].
	(token == $+ or: [token == $-])
		ifFalse: [self error: 'unknown token ' , token].
	op _ token asSymbol] repeat