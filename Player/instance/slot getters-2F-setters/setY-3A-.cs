setY: val
	"Set the y coordinate as indicated"

	| aCostume |
	(aCostume _ self costume) isInWorld ifFalse: [^ self].
	aCostume isWorldOrHandMorph ifTrue: [^ self].
	aCostume owner isHandMorph ifTrue: [^ self].
	^ aCostume y: val