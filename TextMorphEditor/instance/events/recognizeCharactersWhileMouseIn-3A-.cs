recognizeCharactersWhileMouseIn: box
	"Recognize hand-written characters and put them into the receiving TextMorph.  Invokes Alan's character recognizer.  box is in world coordinates."

	| aRecognizer |
	Cursor marker showWhile:
		[aRecognizer _ CharRecog new textMorph: morph.
		aRecognizer recognizeAndDispatch:
			[:char | morph handleInteraction:
				[char == BS
					ifTrue:
						[self simulatedBackspace]
					ifFalse:
						[self simulatedKeystroke: char]] fromEvent: nil.
			morph updateFromParagraph.
			morph world doOneCycle]
		until:
			[(box containsPoint: Sensor cursorPoint) not]]