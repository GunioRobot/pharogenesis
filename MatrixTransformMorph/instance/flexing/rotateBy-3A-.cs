rotateBy: delta
	| pt m |
	delta = 0.0 ifTrue:[^self].
	self changed.
	pt _ self transformFromWorld globalPointToLocal: self referencePosition.
	m _ MatrixTransform2x3 withOffset: pt.
	m _ m composedWithLocal: (MatrixTransform2x3 withAngle: delta).
	m _ m composedWithLocal: (MatrixTransform2x3 withOffset: pt negated).
	self transform: (transform composedWithLocal: m).
	self changed.