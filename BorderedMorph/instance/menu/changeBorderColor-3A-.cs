changeBorderColor: evt
	| aHand |
	aHand _ evt ifNotNil: [evt hand] ifNil: [self primaryHand].
	aHand changeColorTarget: self selector: #borderColor:.
