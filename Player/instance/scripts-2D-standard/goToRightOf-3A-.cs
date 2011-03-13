goToRightOf: aPlayer

	| hisCostume |
	(aPlayer == nil or: [aPlayer == self]) ifTrue: [^ self].
	(hisCostume _ aPlayer costume) isInWorld ifFalse: [^ self].
	(costume owner == hisCostume owner) ifFalse:
		[hisCostume owner addMorphFront: costume].
	costume position:
		(hisCostume bounds rightCenter - (0 @ (costume height // 2)))