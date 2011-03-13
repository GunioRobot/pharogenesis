addTrashCan
	| aControl aPosition |
	(associatedMorph findA: TrashCanMorph) ifNotNil: [^ self].
	aControl _ TrashCanMorph newSticky.
	aPosition _ associatedMorph positionNear: (associatedMorph bottomRight - (58@76)) forExtent: aControl extent adjustmentSuggestion:  (-10 @ 0).
	aControl position: aPosition.
	associatedMorph addMorph: aControl.
	aControl startStepping.
	aControl setProperty: #scriptingControl toValue: true.
