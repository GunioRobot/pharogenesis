detectNonSmoothVertices
	"Detect all the vertices in the receiver that cannot be easily smoothed"
	| mask face flag vtxIndex out newMask |
	smoothFlags ifNil:[^#()].
	mask _ WordArray new: vertices size.
	mask atAllPut: 16rFFFFFFFF.
	out _ Set new: 1000. "Leave us enough space to avoid collisions"
	1 to: faces size do:[:i|
		face _ faces at: i.
		flag _ smoothFlags at: i.
		1 to: 3 do:[:j|
			vtxIndex _ face at: j.
			newMask _ ((mask at: vtxIndex) bitAnd: flag).
			newMask = 0 ifTrue:[out add: vtxIndex].
			mask at: vtxIndex put: newMask.
		].
	].
	^out