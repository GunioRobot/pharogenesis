mouseUpEvent: event noteMorph: noteMorph pitch: midiKey

	midiPort ifNil: [
		^ super mouseUpEvent: event noteMorph: noteMorph pitch: midiKey].

	noteMorph color:
		((#(0 1 3 5 6 8 10) includes: midiKey \\ 12)
			ifTrue: [whiteKeyColor]
			ifFalse: [blackKeyColor]).
	soundPlaying ifNotNil: [self turnOffNote].
