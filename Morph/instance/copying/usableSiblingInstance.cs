usableSiblingInstance
	"Return another similar morph whose Player is of the same class as mine.
	Do not open it in the world."

	| aName usedNames newPlayer newMorph topRenderer |
	(topRenderer := self topRendererOrSelf) == self 
		ifFalse: [^topRenderer usableSiblingInstance].
	self assuredPlayer assureUniClass.
	newMorph := self veryDeepCopySibling.
	newPlayer := newMorph player.
	newPlayer resetCostumeList.
	(aName := self knownName) isNil 
		ifTrue: [self player notNil ifTrue: [aName := newMorph innocuousName]].
	"Force a difference here"
	aName notNil 
		ifTrue: 
			[usedNames := (self world ifNil: [OrderedCollection new]
						ifNotNil: [self world allKnownNames]) copyWith: aName.
			newMorph setNameTo: (Utilities keyLike: aName
						satisfying: [:f | (usedNames includes: f) not])].
	newMorph privateOwner: nil.
	newPlayer assureEventHandlerRepresentsStatus.
	self presenter flushPlayerListCache.
	^newMorph