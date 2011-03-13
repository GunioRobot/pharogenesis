firstIntersectionWithLineFrom: start to: end
	| intersections last |
	intersections _ self fullBounds extrapolatedIntersectionsWithLineFrom: start to: end.
	intersections size = 1 ifTrue: [ ^intersections anyOne ].
	intersections isEmpty ifTrue: [ ^nil ].
	intersections _ intersections asSortedCollection: [ :a :b | (start dist: a) < (start dist: b) ].
	last _ intersections first rounded.
	last pointsTo: intersections last rounded do: [ :pt |
		(self rotatedForm isTransparentAt: (pt - bounds origin)) ifFalse: [ ^last ].
		last _ pt.
	].
	^intersections first rounded