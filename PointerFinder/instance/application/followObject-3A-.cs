followObject: anObject
	(self follow: anObject class from: anObject)
		ifTrue: [^ true].
	"Remove this after switching to new CompiledMethod format --bf 2/12/2006"
	anObject isCompiledMethod ifTrue: [
		1 to: anObject numLiterals do:
			[:i |
			(self follow: (anObject literalAt: i) from: anObject)
				ifTrue: [^ true]].
		^false].
	1 to: anObject class instSize do:
		[:i |
		(self follow: (anObject instVarAt: i) from: anObject)
			ifTrue: [^ true]].
	1 to: anObject basicSize do:
		[:i |
		(self follow: (anObject basicAt: i) from: anObject)
			ifTrue: [^ true]].
	^ false