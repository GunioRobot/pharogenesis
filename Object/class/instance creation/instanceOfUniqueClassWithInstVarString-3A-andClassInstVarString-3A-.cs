instanceOfUniqueClassWithInstVarString: instVarString andClassInstVarString: classInstVarString
	"Create a unique class for the receiver, and answer an instance of it"

	| aName aClass |
	self isSystemDefined ifFalse:
		[^ superclass instanceOfUniqueClassWithInstVarString: instVarString andClassInstVarString: classInstVarString].
	aName _ self chooseUniqueClassName.
	aClass _ self subclass: aName instanceVariableNames: instVarString classVariableNames: '' poolDictionaries: '' category: self categoryForUniclasses.
	classInstVarString size > 0 ifTrue:
		[aClass class instanceVariableNames: classInstVarString].
	^ aClass initialInstance