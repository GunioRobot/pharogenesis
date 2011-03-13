addListener: anObject to: aListenerGroup
	"Add anObject to the given listener group. Return the new group."
	| listeners |
	listeners _ aListenerGroup.
	(listeners notNil and:[listeners includes: anObject]) ifFalse:[
		listeners
			ifNil:[listeners _ WeakArray with: anObject]
			ifNotNil:[listeners _ listeners copyWith: anObject]].
	listeners _ listeners copyWithout: nil. "obsolete entries"
	^listeners