literalEquality: x and: y

	^ (x class = Array and: [y class = Array]) ifTrue: [
		self arrayEquality: x and: y.
	] ifFalse: [
		(x class == y class) and: [x = y]
	].
