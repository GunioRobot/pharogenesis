getterSelectorFor: identifier
	"Answer the corresponding getter.  Two idiosyncratic vectorings herein... " 

	"Utilities getterSelectorFor: #elvis"

	| aSymbol |
	(aSymbol _ identifier asSymbol) == #isOverColor: ifTrue: [^ #seesColor:].
	aSymbol == #copy ifTrue: [^ #getNewClone].

	^ ('get', (identifier asString capitalized)) asSymbol