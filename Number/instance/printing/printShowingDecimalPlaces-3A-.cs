printShowingDecimalPlaces: placesDesired
	"Print the receiver showing precisely the given number of places desired.  If placesDesired is positive, a decimal point and that many digits after the decimal point will always be shown.  If placesDesired is zero, a whole number will be shown, without a decimal point.  It now handles negative numbers between 0 and -1 and rounds correctly in more cases.  This method probably could be optimized -- improvements welcomed.  Category was/is 'converting' but should be 'printing' "

	| precision rounded frac sign integerString fractionString result |
	placesDesired <= 0 ifTrue: [^ self rounded printString].
	precision _ Utilities floatPrecisionForDecimalPlaces: placesDesired.
	rounded _ self roundTo: precision.
	sign := rounded negative ifTrue: ['-'] ifFalse: [''].
	integerString := rounded abs integerPart asInteger printString.
	frac := ((rounded abs fractionPart roundTo: precision) * (10 raisedToInteger: placesDesired)) asInteger.
	fractionString := frac printString padded: #right to: placesDesired with: $0.
	result := sign , integerString , '.' , fractionString.
	^result
"
23 printShowingDecimalPlaces: 2
23.5698 printShowingDecimalPlaces: 2
-234.567 printShowingDecimalPlaces: 5
23.4567 printShowingDecimalPlaces: 0
23.5567 printShowingDecimalPlaces: 0
-23.4567 printShowingDecimalPlaces: 0
-23.5567 printShowingDecimalPlaces: 0
100000000 printShowingDecimalPlaces: 1
0.98 printShowingDecimalPlaces: 2
-0.98 printShowingDecimalPlaces: 2
2.567 printShowingDecimalPlaces: 2
-2.567 printShowingDecimalPlaces: 2
0 printShowingDecimalPlaces: 2
Number categoryForSelector: #printShowingDecimalPlaces:
"