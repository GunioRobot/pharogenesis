goToRightOf: aPlayer
	"Place the object so that it lies directly to the right of the given object"

	| hisCostume aCostume |
	(aPlayer == nil or: [aPlayer == self]) ifTrue: [^ self].
	(hisCostume _ aPlayer costume) isInWorld ifFalse: [^ self].
	((aCostume _ self costume) owner == hisCostume owner) ifFalse:
		[hisCostume owner addMorphFront: aCostume].
	aCostume position:
		(hisCostume bounds rightCenter - (0 @ (aCostume height // 2)))