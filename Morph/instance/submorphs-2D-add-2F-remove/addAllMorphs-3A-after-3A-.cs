addAllMorphs: aCollection after: anotherMorph

	| index box any invalidate myWorld itsWorld |
	myWorld _ self world.
	invalidate _ myWorld notNil.
	box _ nil.
	index _ submorphs indexOf: anotherMorph ifAbsent: [submorphs size].
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
	submorphs _ (submorphs copyFrom: 1 to: index), aCollection,
			(submorphs copyFrom: index+1 to: submorphs size).
	self layoutChanged.
	box ifNotNil:[self invalidRect: box from: any].