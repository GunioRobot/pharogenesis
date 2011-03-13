recognizeAndPutInTranscript
	"Call Alan's recognizer repeatedly until the mouse is near the left edge of the screen, and dispatch keystrokes inferred to the Trancript.  2/2/96 sw"

	^ self recognizeAndDispatch:

		[:char | (char = 'cr') ifTrue: [Transcript cr] ifFalse:
						[char = 'bs' ifTrue: [Transcript bs] ifFalse:
						[char = 'tab' ifTrue:[Transcript tab] ifFalse:
						[Transcript show: char]]]]

		until:
			[Sensor mousePoint x < 50]

"CharRecog new recognizeAndPutInTranscript"