parseListEntries: listResult

	| c first |
	c _ self fastParseEntriesFrom: listResult.
	c ifNotNil: [^c].
	c _ OrderedCollection new.
	first _ true.
	listResult linesDo: [ :x |
		first ifFalse: [c add: (Compiler evaluate: x)].
		first _ false.
	].
	^c
