inspectGlobals
	"Utilities  inspectGlobals"
	| associations aDict |
	associations _ ((Smalltalk keys select: [:aKey | ((Smalltalk at: aKey) isKindOf: Class) not]) asSortedArray collect:
		[:aKey | Smalltalk associationAt: aKey]).
	aDict _ IdentityDictionary new.
	associations do: [:as | aDict add: as].
	aDict inspectWithLabel: 'The Globals'