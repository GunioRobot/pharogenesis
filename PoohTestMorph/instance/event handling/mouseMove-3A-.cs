mouseMove: evt
	(lastPoint notNil and:[(lastPoint dist: evt position) < 5])  ifTrue:[^self].
	lastPoint _ evt position.
	points ifNil:[points _ WriteStream on: (Array new: 100)].
	points nextPut: (evt position - bounds origin).
	self changed.