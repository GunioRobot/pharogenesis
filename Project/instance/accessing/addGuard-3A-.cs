addGuard: anObject
	"Add the given object to the list of objects receiving #okayToEnterProject on Project entry"
	guards ifNil:[guards _ WeakArray with: anObject]
			ifNotNil:[guards _ guards copyWith: anObject].