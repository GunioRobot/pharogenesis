validFacesDo: aBlock
	| tmp |
	tmp _ self.
	[tmp == nil] whileFalse:[
		tmp isValid ifTrue:[aBlock value: tmp].
		tmp _ tmp next].