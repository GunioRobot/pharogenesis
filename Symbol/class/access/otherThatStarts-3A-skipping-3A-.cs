otherThatStarts: leadingCharacters skipping: skipSym
	"Answer a selector symbol with leadingCharacters that 
		starts with an uppercase letter. Ignore case in aKeyword.
	If skipSym is not nil, it is a previous answer; start searching after it.
	If no symbols are found, answer nil.
	Used by Alt-q (Command-q) routines."

	| key size table candidate ii skip |
	key _ leadingCharacters asLowercase.
	size _ key size.
	skip _ skipSym ~~ nil.
	(1 to: OtherTable size) do:
		[:jj |
		table _ OtherTable at: jj.
		1 to: table size do: 
			[:tt | 
			((candidate _ table at: tt) == nil or:
					[skip and: [skip _ candidate ~~ skipSym. true]]) ifFalse:
				[candidate size >= size ifTrue:
					[ii _ size. "test last character first"
					 [ii > 0 and: [(candidate at: ii) asLowercase == (key at: ii)]]
						whileTrue: [ii _ ii - 1].
					 ii = 0 ifTrue: [^candidate]]]]].
	^nil

"Symbol otherThatStarts: 'morph' skipping: nil"
"Symbol otherThatStarts: 'morph' skipping: #'Morphic-Support'"
"Symbol otherThatStarts: 'rect' skipping: #'rectangle functions'"
