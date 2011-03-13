mouseUpEvent: event noteMorph: noteMorph pitch: pitch

	noteMorph color: ((#(0 1 3 5 6 8 10) includes: pitch\\12)
					ifTrue: [whiteKeyColor]
					ifFalse: [blackKeyColor]).
	soundPlaying ifNotNil: [soundPlaying stopGracefully].
