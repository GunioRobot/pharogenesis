removeListener: anObject from: aListenerGroup
	"Remove anObject from the given listener group. Return the new group."
	| listeners |
	aListenerGroup ifNil:[^nil].
	listeners _ aListenerGroup.
	listeners _ listeners copyWithout: anObject.
	listeners _ listeners copyWithout: nil. "obsolete entries"
	listeners size = 0 ifTrue:[listeners _ nil].
	^listeners