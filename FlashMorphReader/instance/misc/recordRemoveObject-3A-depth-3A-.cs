recordRemoveObject: id depth: depth
	id ifNotNil:["Faster if id is given"
		(activeMorphs at: id ifAbsent:[#()]) do:[:morph|
			((morph visibleAtFrame: frame-1) and:[
				(morph depthAtFrame: frame-1) = depth]) 
					ifTrue:[^self removeActiveMorph: morph]]].
	activeMorphs do:[:list|
		list do:[:morph|
			((morph visibleAtFrame: frame-1) and:[
				(morph depthAtFrame: frame-1) = depth]) 
					ifTrue:[^self removeActiveMorph: morph]]].
	Transcript cr; nextPutAll:'Shape (id = '; print: id; nextPutAll:' depth = '; print: depth; nextPutAll:') not removed in frame '; print: frame; endEntry.
	^nil