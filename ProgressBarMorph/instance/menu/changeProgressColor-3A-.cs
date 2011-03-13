changeProgressColor: evt
	| aHand |
	aHand _ evt ifNotNil: [evt hand] ifNil: [self primaryHand].
	self changeColorTarget: self selector: #progressColor: originalColor: self progressColor hand: aHand.