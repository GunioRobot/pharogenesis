safelyRegisterExternalObject: anObject
	"Register the given object in the external objects array and return its index. If it is already there, just return its index."

	| objects firstEmptyIndex obj sz newObjects |
	objects _ Smalltalk specialObjectsArray at: 39.

	"find the first empty slot"
	firstEmptyIndex _ 0.
	1 to: objects size do: [:i |
		obj _ objects at: i.
		obj == anObject ifTrue: [^ i].  "object already there, just return its index"
		(obj == nil and: [firstEmptyIndex = 0]) ifTrue: [firstEmptyIndex _ i]].

	"if no empty slots, expand the array"
	firstEmptyIndex = 0 ifTrue: [
		sz _ objects size.
		newObjects _ objects species new: sz + 20.  "grow linearly"
		newObjects replaceFrom: 1 to: sz with: objects startingAt: 1.
		firstEmptyIndex _ sz + 1.
		Smalltalk specialObjectsArray at: 39 put: newObjects.
		objects _ newObjects].

	objects at: firstEmptyIndex put: anObject.
	^ firstEmptyIndex
