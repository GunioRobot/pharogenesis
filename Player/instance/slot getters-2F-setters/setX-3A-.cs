setX: val
	"Set the x coordinate as indicated"

	| aCostume |
	(aCostume _ self costume) isInWorld ifFalse: [^ self].
	aCostume isWorldOrHandMorph ifTrue: [^ self].
	aCostume owner isHandMorph ifTrue: [^ self].
	^ aCostume x: val