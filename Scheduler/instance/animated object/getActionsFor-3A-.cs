getActionsFor: anObject
	"Return the animations that list anObject as the object they're affecting"

	| aList |
	aList _ OrderedCollection new.

	actionList do: [:action | ((action getAffectedObject) = anObject)
								ifTrue: [ aList addLast: action ] ].

	^ aList.
