loadLine: line from: point1 to: point2 offset: yOffset leftFill: leftFill rightFill: rightFill
	"Load the line defined by point1 and point2."
	| p1 p2 yDir |
	self var: #point1 declareC:'int *point1'.
	self var: #point2 declareC:'int *point2'.
	self var: #p1 declareC:'int *p1'.
	self var: #p2 declareC:'int *p2'.

	(point1 at: 1) <= (point2 at: 1) 
		ifTrue:[	p1 _ point1.
				p2 _ point2.
				yDir _ 1]
		ifFalse:[	p1 _ point2.
				p2 _ point1.
				yDir _ -1].
	self edgeXValueOf: line put: (p1 at: 0).
	self edgeYValueOf: line put: (p1 at: 1) - yOffset.
	self edgeZValueOf: line put: self currentZGet.
	self edgeLeftFillOf: line put: leftFill.
	self edgeRightFillOf: line put: rightFill.
	self lineEndXOf: line put: (p2 at: 0).
	self lineEndYOf: line put: (p2 at: 1) - yOffset.
	self lineYDirectionOf: line put: yDir.