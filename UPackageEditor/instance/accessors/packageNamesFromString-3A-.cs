packageNamesFromString: aString 
	| depNames |
	depNames := aString asString findTokens: ','.
	depNames := depNames collect: [:d | d withBlanksTrimmed].
	^depNames