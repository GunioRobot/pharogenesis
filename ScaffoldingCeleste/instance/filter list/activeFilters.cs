activeFilters
	| filters |
	filters := OrderedCollection new.
	categoryFilter ifNotNil: [ filters add: categoryFilter ].
	participantFilter ifNotNil: [ filters add: participantFilter ].
	subjectFilter ifNotNil: [ filters add: subjectFilter ].
	codeFilter ifNotNil: [ filters add: codeFilter ].

	^filters