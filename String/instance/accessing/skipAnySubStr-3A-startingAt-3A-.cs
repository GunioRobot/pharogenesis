skipAnySubStr: delimiters startingAt: start 
	"Answer the index of the last character within the receiver, starting at start, that does NOT match one of the delimiters. delimiters is a Array of substrings (Characters also allowed).  If the receiver is all delimiters, answer size + 1."

	| any this ind ii |
	ii _ start-1.
	[(ii _ ii + 1) <= self size] whileTrue: [ "look for char that does not match"
		any _ false.
		delimiters do: [:delim |
			delim class == Character 
				ifTrue: [(self at: ii) == delim ifTrue: [any _ true]]
				ifFalse: ["a substring"
					ind _ 0.
					this _ true.
					delim do: [:dd | 
						dd == (self at: ii+ind) ifFalse: [this _ false].
						ind _ ind + 1].
					this ifTrue: [ii _ ii + delim size - 1.  any _ true]]].
		any ifFalse: [^ ii]].
	^ self size + 1