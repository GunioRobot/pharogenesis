recognizeCharactersWhileMouseIn: box
	"Recognize hand-written characters and put them into the receiving pane.  Invokes Alan's character recognizer.  2/5/96 sw"

	| aRecognizer |
	Cursor marker showWhile:
		[aRecognizer _ CharRecog new.
		aRecognizer recognizeAndDispatch:
			[:char | char == BS
				ifTrue:
					[self simulatedBackspace]
				ifFalse:
					[self simulatedKeystroke: char]]
		until:
			[(box containsPoint: sensor cursorPoint) not]].
	view display