tempsAndBlockArgs
	| tempNodes var |
	tempNodes _ OrderedCollection new.
	scopeTable associationsDo:
		[:assn | var _ assn value.
		((var isTemp and: [var isArg not])
					and: [var scope = 0 or: [var scope = -1]])
			ifTrue: [tempNodes add: var]].
	^ tempNodes