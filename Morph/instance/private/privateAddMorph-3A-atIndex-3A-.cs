privateAddMorph: aMorph atIndex: index

	| oldIndex myWorld itsWorld |
	((index >= 1) and: [index <= (submorphs size + 1)])
		ifFalse: [^ self error: 'index out of range'].
	myWorld _ self world.
	aMorph owner == self ifTrue:[
		"aMorph's position changes within in the submorph chain"
		oldIndex _ submorphs indexOf: aMorph.
		oldIndex < index ifTrue:[
			"moving aMorph to back"
			submorphs replaceFrom: oldIndex to: index-2 with: submorphs startingAt: oldIndex+1.
			submorphs at: index-1 put: aMorph.
		] ifFalse:[
			"moving aMorph to front"
			oldIndex-1 to: index by: -1 do:[:i|
				submorphs at: i+1 put: (submorphs at: i)].
			submorphs at: index put: aMorph.
		].
	] ifFalse:[
		"adding a new morph"
		aMorph owner ifNotNil:[
			itsWorld _ aMorph world.
			itsWorld == myWorld ifFalse:[aMorph outOfWorld: itsWorld].
			aMorph owner privateRemoveMorph: aMorph].
		aMorph privateOwner: self.
		submorphs _ submorphs copyReplaceFrom: index to: index-1 with: (Array with: aMorph).
		itsWorld == myWorld ifFalse:[aMorph intoWorld: myWorld].
	].
	self layoutChanged.
	myWorld ifNotNil:[self invalidRect: aMorph fullBounds from: aMorph].