shrink
	"Shorten the tape by deleting mouseMove events that can just as well be
	interpolated later at playback time."

	| oldSize priorSize |
	self writeCheck.
	oldSize _ priorSize _ tape size.
	[self condense.  tape size < priorSize] whileTrue: [priorSize _ tape size].
	PopUpMenu notify: oldSize printString , ' events reduced to ' , tape size printString.
	voiceRecorder ifNotNil: [voiceRecorder suppressSilence].
	saved _ false.
