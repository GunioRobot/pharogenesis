hasInterned: aString ifTrue: symBlock 
	"Answer with false if aString hasnt been interned (into a Symbol), 
	otherwise supply the symbol to symBlock and return true."

	| table ascii numArgs symbol |

	ascii _ (aString at: 1) asciiValue.
	aString size = 1 ifTrue: [ascii < 128 ifTrue: 
		[symBlock value: (SingleCharSymbols at: ascii + 1).
		^true]].

	table _ ((ascii >= "$a asciiValue" 97) and:
		[(ascii <= "$z asciiValue" 122) and:
		[(numArgs _ aString numArgs) >= 0]])
			ifTrue: [(SelectorTables at: (numArgs + 1 min: SelectorTables size))
						at: ascii - "($a asciiValue - 1)" 96]
			ifFalse: [OtherTable at: aString stringhash \\ OtherTable size + 1].

	1 to: table size do: [:i | 
		symbol _ table at: i.
		(symbol notNil and:[aString size = symbol size and: [aString = symbol]]) ifTrue: [
			symBlock value: symbol.
			^true]
	].
	^false