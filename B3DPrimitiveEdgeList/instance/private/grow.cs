grow
	| newArray |
	newArray _ array species new: array size + 100.
	newArray replaceFrom: 1 to: array size with: array startingAt: 1.
	array _ newArray.