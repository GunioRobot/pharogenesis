thatStarts: leadingCharacters skipping: skipSym
	"Answer a selector symbol that starts with leadingCharacters.
	Symbols beginning with a lower-case letter handled directly here.
	Ignore case after first char.
	If skipSym is not nil, it is a previous answer; start searching after it.
	If no symbols are found, answer nil.
	Used by Alt-q (Command-q) routines."

	| key size index table candidate i skip firstTable |
	key _ leadingCharacters asLowercase.
	index _ key first asciiValue - "($a asciiValue - 1)" 96.
	((index >= 1) and:
		[(index <= 26) and:
		[leadingCharacters numArgs >= 0]])
			ifFalse: [^ self otherThatStarts: leadingCharacters skipping: skipSym].
	size _ key size.
	skip _ skipSym ~~ nil.
	firstTable _ skip
		ifTrue: [skipSym numArgs + 1 min: SelectorTables size] "can't be in a later table"
		ifFalse: [SelectorTables size]. "could be in any table; favor longer identifiers"
	(firstTable to: 1 by: -1) do:
		[:j |
		table _ (SelectorTables at: j) at: index.
		1 to: table size do: 
			[:t | 
			((candidate _ table at: t) == nil or:
					[skip and: [skip _ candidate ~~ skipSym. true]]) ifFalse:
				[candidate size >= size ifTrue:
					[i _ size. "test last character first"
					 [i > 1 and: [(candidate at: i) asLowercase == (key at: i)]]
						whileTrue: [i _ i - 1].
					 i = 1 ifTrue: "don't need to compare first character"
						[^candidate]]]]].
	^nil

"Symbol thatStarts: 'sf' skipping: nil"
"Symbol thatStarts: 'sf' skipping: #sfpGetFile:with:with:with:with:with:with:with:with:"
"Symbol thatStarts: 'candidate' skipping: nil"
