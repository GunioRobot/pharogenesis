stepToFrameForward: frame
	| activeRemoved resortNeeded morph |
	frameNumber+1 to: frame do:[:f|
		activeRemoved := false.
		resortNeeded := false.
		1 to: activeMorphs size do:[:i|
			morph := activeMorphs at: i.
			morph stepToFrame: f.
			morph visible ifFalse:[activeRemoved := true].
			(i > 1 and:[(activeMorphs at: i-1) depth < morph depth])
				ifTrue:[resortNeeded := true].
		].
		activeRemoved ifTrue:[
			activeMorphs := activeMorphs select:[:m| m visible].
			resortNeeded := false.
		].
		resortNeeded ifTrue:[activeMorphs reSort].
		(activationKeys at: f) do:[:m|
			m stepToFrame: f.
			m visible ifTrue:[activeMorphs add: m].
		].
	].