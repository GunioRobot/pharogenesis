discardMorphic
	"Discard Morphic.
	Updated for 2.8 TPR"
	"Smalltalk discardMorphic"
	"Check that we are in an MVC Project and that there are no
	Morphic Projects
	or WorldMorphViews."
	| subs |
	Flaps clobberFlapTabList.
	self discardFlash.
	self discardTrueType.
	subs := OrderedCollection new.
	Morph
		allSubclassesWithLevelDo: [:c :i | subs addFirst: c]
		startingLevel: 0.
	subs
		do: [:c | c removeFromSystem].
	self removeClassNamed: #CornerRounder.
	self
		removeKey: #BalloonEngineConstants
		ifAbsent: [].
	SystemOrganization removeCategoriesMatching: 'Balloon-*'.
	SystemOrganization removeCategoriesMatching: 'Morphic-*'.
	SystemOrganization removeSystemCategory: 'Graphics-Transformations'.
	SystemOrganization removeSystemCategory: 'ST80-Morphic'.
	ScriptingSystem := nil