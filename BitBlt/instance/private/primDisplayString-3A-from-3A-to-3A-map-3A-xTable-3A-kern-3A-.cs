primDisplayString: aString from: startIndex to: stopIndex map: glyphMap xTable: xTable kern: kernDelta
	| ascii |
	<primitive:'primitiveDisplayString' module:'BitBltPlugin'>
	startIndex to: stopIndex do:[:charIndex|
		ascii _ (aString at: charIndex) asciiValue.
		sourceX _ xTable at: ascii + 1.
		width _ (xTable at: ascii + 2) - sourceX.
		self copyBits.
		destX _ destX + width + kernDelta.
	].