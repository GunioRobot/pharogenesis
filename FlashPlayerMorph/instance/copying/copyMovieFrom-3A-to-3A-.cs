copyMovieFrom: firstFrame to: lastFrame
	"Create a copy of the receiver containing the given frames"
	| player delta actionList newMorphs |
	delta := firstFrame - 1.
	player := FlashPlayerMorph new.
	player bounds: self bounds.
	player localBounds: self localBounds.
	player maxFrames: lastFrame - firstFrame + 1.
	player loadedFrames: player maxFrames.
	player stepTime: stepTime.
	player color: self color.
	"Copy the sounds, actions and labels"
	sounds associationsDo:[:sndAssoc|
		(sndAssoc key between: firstFrame and: lastFrame) ifTrue:[
			sndAssoc value do:[:snd|
				player addSound: snd at: sndAssoc key - delta]]].
	actions associationsDo:[:action|
		actionList := action value collect:[:a|
			a selector == #gotoFrame: 
				ifTrue:[Message selector: a selector argument: (a argument - delta)]
				ifFalse:[a]].
		(action key between: firstFrame and: lastFrame)
			ifTrue:[player addActions: actionList atFrame: action key - delta]].
	labels associationsDo:[:label|
		(label value between: firstFrame and: lastFrame)
			ifTrue:[player addLabel: label key atFrame: label value - delta]].
	"Finally, copy the morphs"
	newMorphs := submorphs 
					select:[:m| m isVisibleBetween: firstFrame and: lastFrame]
					thenCollect:[:m| m copyMovieFrom: firstFrame to: lastFrame].
	player addAllMorphs: newMorphs.
	player loadInitialFrame.
	player stepToFrame: 1.
	^player