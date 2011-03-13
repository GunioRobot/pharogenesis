lookAt: aPoint
	| theta scale |
	(self containsPoint: aPoint) ifTrue: [self iris align: iris center with: aPoint. ^ self].
	theta := (aPoint - self center) theta.
	scale := (aPoint - self center) r / 100.0 min: 1.0.
	self iris align: self iris center with: self center + (theta cos @ theta sin * self extent / 3.0 * scale) rounded