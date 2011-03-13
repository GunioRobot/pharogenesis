assureNameFor: anObject
	| aName |
	(aName _ self nameFor: anObject) ifNotNil: [^ aName].
	^ self namePartSilently: anObject