setFrameRate
	"Ask the user to specify the desired frame rate."

	| rateString |
	rateString := FillInTheBlank request: 'Desired frames per second?' translated
				initialAnswer: desiredFrameRate printString.
	rateString isEmpty ifTrue: [^self].
	desiredFrameRate := rateString asNumber asFloat.
	desiredFrameRate := desiredFrameRate max: 0.1