changeProgressColor: evt
	| aHand |
	aHand _ evt ifNotNil: [evt hand] ifNil: [self primaryHand].
	aHand changeColorTarget: self selector: #progressColor: originalColor: self progressColor