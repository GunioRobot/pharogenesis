findAnySubStr: delimiters startingAt: start 
	"Answer the index of the character within the receiver, starting at start, that begins a substring matching one of the delimiters.  delimiters is an Array of Strings (Characters are permitted also).  If the receiver does not contain any of the delimiters, answer size + 1."

	| min ind |
	min _ self size + 1.
	delimiters do: [:delim |	"May be a char, a string of length 1, or a substring"
		delim isCharacter
			ifTrue: [ind _ self indexOfSubCollection: (MultiString with: delim) 
						startingAt: start ifAbsent: [min]]
			ifFalse: [ind _ self indexOfSubCollection: (MultiString from: delim) 
						startingAt: start ifAbsent: [min]].
			min _ min min: ind].
	^ min.
