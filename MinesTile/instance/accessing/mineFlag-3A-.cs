mineFlag: boolean

	mineFlag _ boolean.
	mineFlag ifTrue: [
		self color: Color red lighter lighter lighter lighter.]
		ifFalse: [
		self color: self preferredColor.].
	^ mineFlag.
