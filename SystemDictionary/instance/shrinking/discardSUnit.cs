discardSUnit
	"Smalltalk discardSUnit"
	| oc |
	oc := OrderedCollection new.
	(self
		at: #TestCase
		ifAbsent: [^ self])
		allSubclassesWithLevelDo: [:c :i | oc addFirst: c]
		startingLevel: 0.
	oc
		do: [:c | c removeFromSystem].
	SystemOrganization removeCategoriesMatching: 'SUnit-*'