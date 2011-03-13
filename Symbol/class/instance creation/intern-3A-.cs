intern: aString 
	"Answer a unique Symbol whose characters are those of aString."

	| ascii table mainTable index sym numArgs |

	ascii _ (aString at: 1) asciiValue.
	aString size = 1 ifTrue: [ascii < 128 ifTrue: 
		[^ SingleCharSymbols at: ascii + 1]].

	table _ ((ascii >= "$a asciiValue" 97) and:
		[(ascii <= "$z asciiValue" 122) and:
		[(numArgs _ aString numArgs) >= 0]])
			ifTrue: [ (mainTable _ SelectorTables
									at: (numArgs + 1 min: SelectorTables size))
						at: (index _ ascii - "($a asciiValue - 1)" 96) ]
			ifFalse: [ (mainTable _ OtherTable)
						at: (index _ aString stringhash \\ OtherTable size + 1)].

	1 to: table size do: 
		[:i | 
		(table at: i) == nil 
			ifFalse: [aString size = (table at: i) size ifTrue: [aString = (table at: i)
						ifTrue: 
							[^ table at: i]]]].

	sym _ (aString isMemberOf: Symbol)
		ifTrue: [aString]	 "putting old symbol in new table"
		ifFalse: [(Symbol new: aString size) string: aString]. "create a new one"

	mainTable at: index put: (table copyWith: sym).
	^sym
