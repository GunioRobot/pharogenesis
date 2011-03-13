newFromEFontBDFFile: aFileName name: aString startRange: start endRange: end 
	| n |
	n := self new.
	n 
		readEFontBDFFromFile: aFileName
		name: aString
		rangeFrom: start
		to: end.
	^ n

	"TextConstants at: #Helvetica put: (TextStyle fontArray: {StrikeFont newFromBDFFile: 'helvR12.bdf' name: 'Helvetica12'})"
	"TextConstants at: #Lucida put: (TextStyle fontArray: {StrikeFont newFromBDFFile: 'luRS12.bdf' name: 'Lucida'})"
	"TextStyle default fontAt: 5 put: (StrikeFont new readFromStrike2: 'helv12.sf2')."