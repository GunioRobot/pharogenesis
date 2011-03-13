placeToBreak: proposedKeyword
	"If the selector has multiple keywords and there is a place to split where each half is a known selector, then return the index of the keyword after which to break, else zero."
	| keys strm |
	keys _ proposedKeyword keywords.
	keys size < 2 ifTrue: [^ 0].
	"Try every possible split"
	strm _ WriteStream on: (String new: 30).
	1 to: keys size-1 do: [:index | 
		strm reset.
		1 to: index do: [:one | strm nextPutAll: (keys at: one)].
		Symbol hasInterned: strm contents ifTrue:
			[:aSymbol | 
			strm reset.
			index+1 to: keys size do:
				[:one | strm nextPutAll: (keys at: one)].
				Symbol hasInterned: strm contents ifTrue:
					[:another | ^ index "We have a winnah!"]]].
	^ 0  "just a new or misspelled selector"