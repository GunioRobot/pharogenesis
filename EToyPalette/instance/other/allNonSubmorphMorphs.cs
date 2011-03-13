allNonSubmorphMorphs
	"Return a collection containing all morphs in this morph which are not currently in the submorph containment hierarchy (put in primarily for bookmorphs)"

	| aList |
	aList _ OrderedCollection new.
	currentPalette == controlsPalette ifFalse:
		[aList add: controlsPalette].
	currentPalette == suppliesPalette ifFalse:
		[aList add: suppliesPalette].
	currentPalette == userStuffPalette ifFalse:
		[aList add: userStuffPalette].
	^ aList