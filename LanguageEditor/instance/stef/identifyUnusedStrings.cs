identifyUnusedStrings
	"self new identifyUnusedStrings"
	translationsList getList
		do: [:each | 
			Transcript show: each.
			Transcript show: (Smalltalk
					allSelect: [:method | method
							hasLiteralSuchThat: [:lit | lit class == String
									and: [lit includesSubstring: each caseSensitive: true]]]) size printString; cr]