addCustomMenuItems: aCustomMenu hand: aHandMorph

	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	deleteOnMouseUp
		ifTrue: [aCustomMenu add: 'stay up' action: #toggleDeleteOnMouseUp]
		ifFalse: [aCustomMenu add: 'do not stay up' action: #toggleDeleteOnMouseUp].
	updateContinuously
		ifTrue: [aCustomMenu add: 'update only at end' action: #toggleUpdateContinuously]
		ifFalse: [aCustomMenu add: 'update continuously' action: #toggleUpdateContinuously].
