doOneCycleFor: aWorld

	self interCyclePause: (Preferences higherPerformance ifTrue: [1] ifFalse: [MinCycleLapse]).
	self doOneCycleNowFor: aWorld.