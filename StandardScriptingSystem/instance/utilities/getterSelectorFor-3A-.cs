getterSelectorFor: identifier
	"Some idiosyncratic substitutions here..."

	| aSymbol |
	(aSymbol _ identifier asSymbol) == #isOverColor: ifTrue: [^ #seesColor:].
	aSymbol == #copy ifTrue: [^ #getNewClone].

	^ Utilities getterSelectorFor: aSymbol