addTrashCan
	| aPosition aCan |
	(aCan _ associatedMorph findA: TrashCanMorph) ifNotNil: [^ aCan].
	aCan _ TrashCanMorph newSticky.
	aPosition _ associatedMorph positionNear: (associatedMorph bottomRight - aCan extent) forExtent: aCan extent adjustmentSuggestion:  (-10 @ 0).
	aCan position: aPosition.
	associatedMorph addMorph: aCan.
	aCan startStepping.
	aCan setToAdhereToEdge: #bottomRight.
	^ aCan
