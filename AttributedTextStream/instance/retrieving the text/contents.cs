contents
	| ans |
	ans _ Text new: characters size.
	ans setString: characters contents  setRuns: attributeRuns.   "this is declared private, but it's exactly what I need, and it's declared as exactly what I want it to do...."
	^ans