addDependent: anObject 
	"Add anObject as one of the receiver's dependents.  Uniform with generic #addDependent:, returns the newly-object dependent, though this feature is not used anywhere in the base system.  1/23/96 sw"

	dependents == nil
		ifTrue: 
			[dependents _ OrderedCollection with: anObject]
		ifFalse:
			[dependents add: anObject].
	^ anObject