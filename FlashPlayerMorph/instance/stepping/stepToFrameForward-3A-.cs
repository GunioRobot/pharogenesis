stepToFrameForward: frame
	| activeRemoved resortNeeded morph |
	frameNumber+1 to: frame do:[:f|
		activeRemoved _ false.
		resortNeeded _ false.
		1 to: activeMorphs size do:[:i|
			morph _ activeMorphs at: i.
			morph stepToFrame: f.
			morph visible ifFalse:[activeRemoved _ true].
			(i > 1 and:[(activeMorphs at: i-1) depth < morph depth])
				ifTrue:[resortNeeded _ true].
		].
		activeRemoved ifTrue:[
			activeMorphs _ activeMorphs select:[:m| m visible].
			resortNeeded _ false.
		].
		resortNeeded ifTrue:[activeMorphs reSort].
		(activationKeys at: f) do:[:m|
			m stepToFrame: f.
			m visible ifTrue:[activeMorphs add: m].
		].
	].