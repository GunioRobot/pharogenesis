listFromResult: resultString
	"ResultString is of the form '(data1 op data2) (...)'. Answer a sorted array."
	| resultArray |
	resultString first == $( ifFalse: [^#()].
	resultArray _ (resultString findTokens: '(') collect:
			[:s | s withBlanksTrimmed allButLast "remove $)"].
	resultArray sortBy: [:a :b | 
		(a copyFrom: 6 to: a size) < (b copyFrom: 6 to: b size)].
	^resultArray
