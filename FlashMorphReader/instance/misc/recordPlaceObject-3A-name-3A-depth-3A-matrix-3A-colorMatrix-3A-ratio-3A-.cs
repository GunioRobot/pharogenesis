recordPlaceObject: objectIndex name: aString depth: depth matrix: matrix colorMatrix: colorTransform ratio: ratio
	| cached active doLoad |
	cached := passiveMorphs at: objectIndex ifAbsent:[#()].
	cached size >= 1 
		ifTrue:["Got an old morph. Re-use it"
				doLoad := false.
				active := cached first.
				passiveMorphs at: objectIndex put: (cached copyWithout: active)]
		ifFalse:["Need a new morph"
				doLoad := true.
				active := self newMorphFromShape: objectIndex.
				active isNil ifTrue:[^self].
				active reset.
				active visible: false atFrame: frame - 1].
	active isNil ifTrue:[^self].
	active visible: true atFrame: frame.
	active depth: depth atFrame: frame.
	active matrix:  matrix atFrame: frame.
	active colorTransform: colorTransform atFrame: frame.
	doLoad ifTrue:[
		active loadInitialFrame.
		player addMorph: active].
	cached := (activeMorphs at: objectIndex ifAbsent:[#()]) copyWith: active.
	activeMorphs at: objectIndex put: cached.
	aString ifNotNil:[active setNameTo: aString].
	ratio ifNotNil:[active ratio: ratio atFrame: frame].