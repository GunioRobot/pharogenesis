midpoint
	"Answer the midpoint along my segments"
	| middle |
	middle _ 0.
	self lineSegmentsDo: [ :a :b | middle _ middle + (a dist: b) ].
	middle < 2 ifTrue: [ ^ self center ].
	middle _ middle / 2.
	self lineSegmentsDo: [ :a :b | | dist |
		dist _ (a dist: b).
		middle < dist
			ifTrue: [ ^(a + ((b - a) * (middle / dist))) asIntegerPoint ].
		middle _ middle - dist.
	].
	self error: 'can''t happen'