discardMorphic
   "Smalltalk discardMorphic"
	"Discard Morphic.
Updated for 2.8 TPR"

	| subs |
	"Check that we are in an MVC Project and that there are no Morphic Projects
		or WorldMorphViews."
	Utilities clobberFlapTabList.
	Smalltalk discardFlash.
	Smalltalk discardTrueType.
	subs _ OrderedCollection new.
	Morph allSubclassesWithLevelDo: [:c :i | subs addFirst: c]
		startingLevel: 0.
	subs do: [:c | c removeFromSystem].
	Smalltalk removeClassNamed: #CornerRounder.
	Smalltalk removeKey: #BalloonEngineConstants ifAbsent: [].
	SystemOrganization removeCategoriesMatching: 'Balloon-*'.
	SystemOrganization removeCategoriesMatching: 'Morphic-*'.
	SystemOrganization removeSystemCategory: 'Graphics-Transformations'.
	SystemOrganization removeSystemCategory: 'ST80-Morphic'.

