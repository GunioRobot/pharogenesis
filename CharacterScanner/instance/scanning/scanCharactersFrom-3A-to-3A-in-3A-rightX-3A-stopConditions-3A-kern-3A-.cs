scanCharactersFrom: startIndex to: stopIndex in: sourceString rightX: rightX stopConditions: stops kern: kernDelta
	"This method will perform text scanning with kerning."
	line first = startIndex ifTrue: [
		"handle indentation"
		self indentationLevel timesRepeat: [ self tab ] ].
	^self primScanCharactersFrom: startIndex to: stopIndex in: sourceString 
			rightX: rightX stopConditions: stops kern: kernDelta
