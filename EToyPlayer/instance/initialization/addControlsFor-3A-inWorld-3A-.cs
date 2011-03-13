addControlsFor: anEToyHolder inWorld: aWorld
	| takataka |
	self addStopStepGoButtonsTo: aWorld.

	takataka _ TrashCanMorph newSticky position: aWorld extent - (58 @ 76).
	aWorld addMorph: takataka.
	takataka setProperty: #scriptingControl toValue: true.
	takataka startStepping.
	self addLowerLeftButtonsTo: aWorld.
