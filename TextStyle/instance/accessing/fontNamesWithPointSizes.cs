fontNamesWithPointSizes
	^ fontArray collect:
		[:x | x name withoutTrailingDigits, ' ', x pointSize printString]

  "TextStyle default fontNamesWithPointSizes"