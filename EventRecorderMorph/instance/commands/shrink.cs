shrink
	"Shorten the tape by deleting mouseMove events that can just as well be
	interpolated later at playback time."

	| oldSize priorSize |
	self writeCheck.
	oldSize _ priorSize _ tape size.
	[self condense.  tape size < priorSize] whileTrue: [priorSize _ tape size].
	self inform: ('{1} events reduced to {2}' translated format:{oldSize. tape size}).
	voiceRecorder ifNotNil: [voiceRecorder suppressSilence].
	saved _ false.
