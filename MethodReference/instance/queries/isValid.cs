isValid
	"Answer whether the receiver represents a current selector or Comment"

	| aClass |
	(#(DoIt DoItIn:) includes: methodSymbol) ifTrue: [^ false].
	(aClass _ self actualClass) ifNil: [^ false].
	^ (aClass includesSelector: methodSymbol) or:
		[methodSymbol == #Comment]