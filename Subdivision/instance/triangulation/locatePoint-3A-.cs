locatePoint: aPoint
	"Returns an edge e, s.t. either x is on e, or e is an edge of
	a triangle containing x. The search starts from startingEdge
	and proceeds in the general direction of x. Based on the
	pseudocode in Guibas and Stolfi (1985) p.121."

	| edge |
	edge := startingEdge first.
	[true] whileTrue:[
		(aPoint = edge origin or:[aPoint = edge destination]) ifTrue:[^edge].
		(edge isRightPoint: aPoint) ifTrue:[edge := edge symmetric]
		ifFalse:[(edge originNext isRightPoint: aPoint) ifFalse:[edge := edge originNext]
		ifTrue:[(edge destPrev isRightPoint: aPoint) ifFalse:[edge := edge destPrev]
		ifTrue:[^edge]]]].