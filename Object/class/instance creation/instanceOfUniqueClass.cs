instanceOfUniqueClass
	"Create a unique class for the receiver, and answer an instance of it"

	| aName aClass |
	self isSystemDefined ifFalse:
		[^ superclass instanceOfUniqueClass].
	aName _ self chooseUniqueClassName.
	aClass _ self subclass: aName instanceVariableNames: '' classVariableNames: '' poolDictionaries: '' category: 'Morphic-UserObjects'.
	^ aClass new