borderStyleForSymbol: sym
	"Answer a border style corresponding to the given symbol"

	| aSymbol |
	aSymbol := sym == #none ifTrue: [#simple] ifFalse: [sym].
	^ self perform: aSymbol
"
	| aSymbol selector |
	aSymbol := sym == #none ifTrue: [#simple] ifFalse: [sym].
	selector := Vocabulary eToyVocabulary translationKeyFor: aSymbol.
	selector isNil ifTrue: [selector := aSymbol].
	^ self perform: selector
"
