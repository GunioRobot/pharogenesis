eventSelectorFor: aString
	"Make an ST80 type message from aString"
	| selector |
	(aString beginsWith: 'set_') ifTrue:[
		selector _ aString copyFrom: 5 to: aString size.
	] ifFalse:[
		selector _ aString.
	].
	selector _ selector copyReplaceAll:'_' with: ''.
	selector _ selector copyWith: $:.
	^selector asSymbol