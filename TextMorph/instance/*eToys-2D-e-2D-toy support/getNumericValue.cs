getNumericValue
	"Obtain a numeric value from the receiver; if no digits, return zero"

	| aString |
	^ [(aString := text string) asNumber] ifError: [:a :b | ^ aString asInteger ifNil: [0]]