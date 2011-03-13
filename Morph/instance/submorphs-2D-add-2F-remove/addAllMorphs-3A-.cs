addAllMorphs: aCollection
	| any box invalidate myWorld itsWorld |
	myWorld _ self world.
	invalidate _ myWorld notNil.
	box _ nil.
	aCollection do: [:m |
		any _ m.
		m owner ifNotNil: [
			itsWorld _ m world.
			itsWorld == myWorld ifFalse:[m outOfWorld: itsWorld].
			m owner privateRemoveMorph: m].
		invalidate ifTrue:[
			box ifNil:[box _ m fullBounds copy] 
				ifNotNil:[box _ box quickMerge: m fullBounds]].
		m privateOwner: self.
		itsWorld == myWorld ifFalse:[m intoWorld: myWorld].
	].
	submorphs _ submorphs, aCollection.
	self layoutChanged.
	box ifNotNil:[self invalidRect: box from: any].