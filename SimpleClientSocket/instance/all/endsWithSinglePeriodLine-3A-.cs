endsWithSinglePeriodLine: aString
	"Return true if the given string ends with a period on a line by itself."

	| sz |
	sz _ aString size.
	^ ((sz > 2) and:
	   [(aString at: sz) = CR and:
	   [(aString at: sz - 1) = $. and:
	   [(aString at: sz - 2) = CR]]])
