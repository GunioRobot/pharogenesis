segmentsDo: aBlock
	"Evaluate aBlock with the segments of the receiver. This may either be straight line
	segments or quadratic bezier curves. The decision is made upon the type flags
	in TTPoint as follows:
	a) 	To subsequent #OnCurve points define a straight segment
	b) 	A #OnCurve point followed by a #OffCurve point followed 
		by a #TT_ONCURVE point defines a quadratic bezier segment
	c)	Two subsequent #OffCurve points have an implicitely defined 
		#OnCurve point at half the distance between them"
	| last next mid index |
	last _ points first.
	"The first point is _always_ on the curve"
	(last type == #OnCurve) ifFalse:[
		Transcript cr; show:'Bad starting point OffCurve'.
		last type: #OnCurve].
	index _ 2.
	[index <= points size] whileTrue:[
		mid _ points at: index.
		mid type == #OnCurve ifTrue:[
			"Straight segment"
			aBlock value: (LineSegment from: last asPoint to: mid asPoint).
			last _ mid.
		] ifFalse:["Quadratic bezier"
			"Read ahead if the next point is on curve"
			next _ (index < points size) ifTrue:[points at: (index+1)] ifFalse:[points first].
			next type == #OnCurve ifTrue:[
				"We'll continue after the end point"
				index _ index + 1.
			] ifFalse:[ "Calculate center"
				next _ (next asPoint + mid asPoint) // 2].
			aBlock value:(Bezier2Segment from: last asPoint via: mid asPoint to: next asPoint).
			last _ next].
		index _ index + 1].
	(index = (points size + 1)) ifTrue:[
		aBlock value:(LineSegment from: points last asPoint to: points first asPoint)]