breakIfLikely: proposedKeyword intoSel1Sel2Break: successBlock
	"If the selector has multiple keywords and there is a place to split where each half is a known selector, then evaluate the successBlock with the two selectors and the index of the keyword after which to split."
	| keys strm |
	keys _ proposedKeyword keywords.
	keys size < 2 ifTrue: [^ nil].
	"Try every possible split"
	strm _ WriteStream on: (String new: 30).
	1 to: keys size-1 do: [:index | 
		strm reset.
		1 to: index do: [:i | strm nextPutAll: (keys at: i)].
		Symbol hasInterned: strm contents ifTrue:
			[:sel1 | 
			strm reset.
			index+1 to: keys size do:
				[:i | strm nextPutAll: (keys at: i)].
				Symbol hasInterned: strm contents ifTrue:
					[:sel2 |  "We have a winnah!"
					successBlock value: sel1 value: sel2 value: index]]].
	^ nil  "just a new or misspelled selector"