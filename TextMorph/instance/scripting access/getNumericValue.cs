getNumericValue
	"Obtain a numeric value from the receiver; if no digits, return zero"

	| aString |
	^ [(aString _ text string) asNumber] ifError: [:a :b | ^ aString asInteger ifNil: [0]]