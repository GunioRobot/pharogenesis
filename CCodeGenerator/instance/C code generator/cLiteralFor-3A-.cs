cLiteralFor: anObject
	"Return a string representing the C literal value for the given object."
	| s |
	(anObject isKindOf: Integer) ifTrue: [
		(anObject < 16r7FFFFFFF)
			ifTrue: [^ anObject printString]
			ifFalse: [^ anObject printString , 'U']].
	(anObject isKindOf: String) ifTrue: [^ '"', anObject, '"' ].
	(anObject isKindOf: Float) ifTrue: [^ anObject printString ].
	anObject == nil ifTrue: [^ 'null' ].
	anObject == true ifTrue: [^ '1' ].			"ikp"
	anObject == false ifTrue: [^ '0' ].			"ikp"
	self error:								"ikp"
		'Warning: A Smalltalk literal could not be translated into a C constant: ', anObject printString.
	^'"XXX UNTRANSLATABLE CONSTANT XXX"'