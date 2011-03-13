morphicWorldAt: aPoint 
	| roots outer worldCount |

	outer _ self getOuterMorphicWorld ifNil: [^ nil].
	worldCount _ 0.
	outer worldMorphsDo: [ :each | worldCount _ worldCount + 1].
	worldCount < 2 ifTrue: [^outer].
	roots _ outer rootMorphsAt: aPoint.
	roots isEmpty ifTrue: [^ outer].
	^ ((roots first morphsAt: aPoint)
		detect: [:each | true]
		ifNone: [roots first]) world