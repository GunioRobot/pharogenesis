addChar: c
	"add a single character, updating all the tallies"

	"add the character to the output"
	outputStream nextPut: c.

	"update counters for preceeding spaces and preceding newlines"
	(c = Character space or: [ c = Character tab ]) 
	ifTrue: [ precedingSpaces _ precedingSpaces+1.  precedingNewlines _ 0 ]
	ifFalse: [
		(c = Character cr) ifTrue: [
			precedingSpaces _ 0.
			precedingNewlines _ precedingNewlines + 1 ]
		ifFalse: [
			precedingSpaces _ precedingNewlines _ 0 ] ].