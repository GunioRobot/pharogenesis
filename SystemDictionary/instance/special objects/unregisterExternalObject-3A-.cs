unregisterExternalObject: anObject
	"Unregister the given object in the external objects array. Do nothing if it isn't registered."

	| objects |
	anObject ifNil: [^ self].
	objects _ self specialObjectsArray at: 39.
	1 to: objects size do: [:i |
		(objects at: i) == anObject ifTrue: [objects at: i put: nil]].
