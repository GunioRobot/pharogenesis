emitRest

	| sel noteEvent |

	"All this selection logic should be shared with mouseDown..."
	(sel _ pianoRoll selection) ifNil: [^ self].
	insertMode ifTrue:
		[sel _ pianoRoll selectionForInsertion.
		insertMode _ false].
	sel = prevSelection ifFalse:
		["This is a new selection -- need to determine start time"
		sel third = 0
			ifTrue: [startOfNextNote _ 0]
			ifFalse: [startOfNextNote _ ((pianoRoll score tracks at: sel first)
										at: sel third) endTime.
					startOfNextNote _ startOfNextNote + self fullDuration - 1
										truncateTo: self fullDuration]].
	noteEvent _ NoteEvent new time: startOfNextNote; duration: self noteDuration;
			key: -1 "my flag for rest" velocity: self velocity channel: 1.
	pianoRoll appendEvent: noteEvent fullDuration: self fullDuration.
	soundPlaying ifNotNil: [soundPlaying stopGracefully].
	prevSelection _ pianoRoll selection.
	startOfNextNote _ startOfNextNote + self fullDuration.