scanCharactersFrom: startIndex to: stopIndex in: sourceString rightX: rightX stopConditions: stops displaying: display 
	"Primitive. This is the inner loop of text display--but see 
	scanCharactersFrom: to:rightX: which would get the string, 
	stopConditions and displaying from the instance. March through source 
	String from startIndex to stopIndex. If any character is flagged with a 
	non-nil entry in stops, then return the corresponding value. Determine 
	width of each character from xTable. If dextX would exceed rightX, then 
	return stops at: 258. If displaying is true, then display the character. 
	Advance destX by the width of the character. If stopIndex has been 
	reached, then return stops at: 257. Fail under the same conditions that 
	the Smalltalk code below would cause an error. Optional. See Object 
	documentation whatIsAPrimitive."
	| ascii nextDestX maxAscii |
	<primitive: 103>
	maxAscii _ xTable size-2.
	lastIndex _ startIndex.
	[lastIndex <= stopIndex]
		whileTrue: 
			[ascii _ (sourceString at: lastIndex) asciiValue.
			"ascii > maxAscii ifTrue: [ascii _ maxAscii]."
			(stopConditions at: ascii + 1) == nil
				ifFalse: [^stops at: ascii + 1].
			sourceX _ xTable at: ascii + 1.
			nextDestX _ destX + (width _ (xTable at: ascii + 2) - sourceX).
			nextDestX > rightX ifTrue: [^stops at: CrossedX].
			display ifTrue: [self copyBits].
			destX _ nextDestX.
			lastIndex _ lastIndex + 1].
	lastIndex _ stopIndex.
	^stops at: EndOfRun