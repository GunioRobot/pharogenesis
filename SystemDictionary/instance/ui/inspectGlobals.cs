inspectGlobals
	"Smalltalk  inspectGlobals"
	
	| associations aDict |
	associations := ((self  keys select: [:aKey | ((self  at: aKey) isKindOf: Class) not]) asSortedArray collect:[:aKey | self associationAt: aKey]).
	aDict := IdentityDictionary new.
	associations do: [:as | aDict add: as].
	aDict inspectWithLabel: 'The Globals'