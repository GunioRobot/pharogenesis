basicScanCharactersFrom: startIndex to: stopIndex in: sourceString rightX: rightX stopConditions: stops kern: kernDelta
	"Primitive. This is the inner loop of text display--but see 
	scanCharactersFrom: to:rightX: which would get the string, 
	stopConditions and displaying from the instance. March through source 
	String from startIndex to stopIndex. If any character is flagged with a 
	non-nil entry in stops, then return the corresponding value. Determine 
	width of each character from xTable, indexed by map. 
	If dextX would exceed rightX, then return stops at: 258. 
	Advance destX by the width of the character. If stopIndex has been
	reached, then return stops at: 257. Optional. 
	See Object documentation whatIsAPrimitive."
	| ascii nextDestX char |
	<primitive: 103>
	lastIndex _ startIndex.
	[lastIndex <= stopIndex]
		whileTrue: 
			[char _ (sourceString at: lastIndex).
			ascii _ char asciiValue + 1.
			(stops at: ascii) == nil ifFalse: [^stops at: ascii].
			"Note: The following is querying the font about the width
			since the primitive may have failed due to a non-trivial
			mapping of characters to glyphs or a non-existing xTable."
			nextDestX _ destX + (font widthOf: char).
			nextDestX > rightX ifTrue: [^stops at: CrossedX].
			destX _ nextDestX + kernDelta.
			lastIndex _ lastIndex + 1].
	lastIndex _ stopIndex.
	^stops at: EndOfRun