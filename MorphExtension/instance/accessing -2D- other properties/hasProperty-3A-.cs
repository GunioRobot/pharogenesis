hasProperty: aSymbol 
	"Answer whether the receiver has the property named aSymbol"
	| property |
	self hasOtherProperties
		ifFalse: [^ false].
	property _ self otherProperties
				at: aSymbol
				ifAbsent: [].
	property isNil
		ifTrue: [^ false].
	property == false
		ifTrue: [^ false].
	^ true