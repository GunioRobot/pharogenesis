addAngle: aNumber
	| new |
	new := self angle + aNumber.
	self isCircular ifTrue: [new := new \\ self maxAngle].
	self angle: new.
	lastRedraw := lastRedraw + aNumber.
	(lastRedraw abs > 2) ifTrue: [
		lastRedraw := 0.
		self changed]