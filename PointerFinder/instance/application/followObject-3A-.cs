followObject: anObject
	(self follow: anObject class from: anObject)
		ifTrue: [^ true].
	1 to: anObject class instSize do:
		[:i |
		(self follow: (anObject instVarAt: i) from: anObject)
			ifTrue: [^ true]].
	1 to: anObject basicSize do:
		[:i |
		(self follow: (anObject basicAt: i) from: anObject)
			ifTrue: [^ true]].
	^ false