setYRange

	| range |
	range _ FillInTheBlank
		request:
'Type the maximum value for the Y axis'
		initialAnswer: ((yScale * (self width - handleMorph width) / 2.0) roundTo: 0.01) printString.
	range isEmpty ifFalse: [
		yScale _ (2.0 * range asNumber asFloat) / (self width - handleMorph width)].
