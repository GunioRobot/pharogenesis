likelyCategoryToShow
	| aList |
	aList _ scriptedPlayer categories asOrderedCollection.
	self categoryMorphs do:
		[:m | aList remove: m currentCategory ifAbsent: []].

	((aList includes: 'instance variables') and: [scriptedPlayer hasUserDefinedSlots])
		ifTrue:	[^ 'instance variables'].

	((aList includes: 'scripts') and: [scriptedPlayer hasUserDefinedScripts])
		ifTrue:	[^ 'scripts'].

	^ aList size > 0
		ifTrue:
			[aList first]
		ifFalse:
			['basic']