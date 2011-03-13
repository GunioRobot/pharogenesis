discardSUnit   "Smalltalk discardSUnit"
	| oc |
	oc _ OrderedCollection new.
	(Smalltalk at: #TestCase ifAbsent: [^ self])
		allSubclassesWithLevelDo: [:c :i | oc addFirst: c]
		startingLevel: 0.
	oc do: [:c | c removeFromSystem].

	SystemOrganization removeCategoriesMatching: 'SUnit-*'