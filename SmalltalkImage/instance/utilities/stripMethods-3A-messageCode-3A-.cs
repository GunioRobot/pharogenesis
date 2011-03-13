stripMethods: tripletList messageCode: messageString
	"Used to 'cap' methods that need to be protected for proprietary reasons, etc.; call this with a list of triplets of symbols of the form  (<class name>  <#instance or #class> <selector name>), and with a string to be produced as part of the error msg if any of the methods affected is reached"

	| aClass sel keywords codeString |
	tripletList do:
		[:triplet |  
			(aClass := (Smalltalk at: triplet first ifAbsent: [nil])) notNil ifTrue:
				[triplet second == #class ifTrue:
					[aClass := aClass class].
				sel := triplet third.
				keywords := sel keywords.
				(keywords size == 1 and: [keywords first asSymbol isKeyword not])
					ifTrue:
						[codeString := keywords first asString]
					ifFalse:
						[codeString := ''.
						keywords withIndexDo:
							[:kwd :index |
								codeString := codeString, ' ', (keywords at: index), ' ',
									'arg', index printString]].
				codeString := codeString, '
	self codeStrippedOut: ', (messageString surroundedBySingleQuotes).

				aClass compile: codeString classified: 'stripped']]