borderStyleForSymbol: sym
	"Answer a border style corresponding to the given symbol"

	| aSymbol |
	aSymbol _ sym == #none ifTrue: [#simple] ifFalse: [sym].
	^ self perform: aSymbol
"
	| aSymbol selector |
	aSymbol _ sym == #none ifTrue: [#simple] ifFalse: [sym].
	selector _ Vocabulary eToyVocabulary translationKeyFor: aSymbol.
	selector isNil ifTrue: [selector _ aSymbol].
	^ self perform: selector
"
