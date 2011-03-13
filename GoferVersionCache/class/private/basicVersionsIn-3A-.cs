basicVersionsIn: aRepository
	| versions |
	versions := OrderedCollection new.
	aRepository allVersionNames
		do: [ :each | versions addLast: (GoferVersionReference name: each repository: aRepository) ].
	^ versions