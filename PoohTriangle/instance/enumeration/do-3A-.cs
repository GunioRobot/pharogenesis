do: aBlock
	| tmp |
	tmp _ self.
	[tmp == nil] whileFalse:[
		aBlock value: tmp.
		tmp _ tmp next].