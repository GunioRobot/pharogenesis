isVisibleBetween: firstFrame and: lastFrame
	firstFrame to: lastFrame do:[:frameNr| 
		(self visibleAtFrame: frameNr) ifTrue:[^true]].
	^false