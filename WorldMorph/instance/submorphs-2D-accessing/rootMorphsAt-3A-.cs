rootMorphsAt: aPoint
	"Return the list of root morphs containing the given point, excluding the world and its hands."

	| mList |
	mList _ OrderedCollection new.
	submorphs do: [:m |
		((m fullContainsPoint: aPoint) and: [m isLocked not]) ifTrue: [mList addLast: m]].
	^ mList
