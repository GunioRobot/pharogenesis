currentPlayerDo: aBlock
	| aPlayer aPage |
	(aPage _ self currentPage) ifNil: [^ self].
	(aPlayer _ aPage player) ifNotNil:
		[aBlock value: aPlayer]