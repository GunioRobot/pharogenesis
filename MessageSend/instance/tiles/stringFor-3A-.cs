stringFor: anObject
	| generic aName |
	"Return a string suitable for compiling.  Literal or reference from global ref dictionary.  self is always named via the ref dictionary."

	anObject isLiteral ifTrue: [^ anObject printString].
	anObject class == Color ifTrue: [^ anObject printString].
	anObject class superclass == Boolean ifTrue: [^ anObject printString].
	anObject class == BlockContext ifTrue: [^ '[''do nothing'']'].	"default block"
		"Real blocks need to construct tiles in a different way"
	generic _ anObject knownName.	"may be nil or 'Ellipse' "
	aName _ anObject uniqueNameForReference.
	generic = aName ifFalse: [anObject renameTo: aName].
	^ aName
