testRegisteredFlapsQuads
	"Defaults are defined in Flaps class>>defaultQuadsDefining...
	If you change something there, do the following afterwards:
	Flaps initializeFlapsQuads"

	| allQuads absentClasses absentSelectors |
	allQuads _ OrderedCollection new.
	absentClasses _ OrderedCollection new.
	Flaps registeredFlapsQuads valuesDo: [:each | allQuads addAll: each].
	allQuads do: [:each | | theObject |
		theObject _ each at: 1.
		Smalltalk
			at: theObject
			ifAbsent: [absentClasses add: each]].
	self
		assert: absentClasses isEmpty
		description: 'There are absent classes: ' , absentClasses asString.
	absentSelectors _ OrderedCollection new.
	allQuads do: [:each | | theClass theSelector |
		theClass _ (Smalltalk at: (each at: 1)) class.
		theSelector _ each at: 2.
		(theClass canUnderstand: theSelector)
			ifFalse: [absentSelectors add: each]].
	self
		assert: absentSelectors isEmpty
		description: 'There are absent selectors: ' , absentSelectors asString