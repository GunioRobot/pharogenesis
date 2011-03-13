commandHistory
	"Return the command history for the receiver"
	| w |
	(w _ self world) ifNotNil:[^w commandHistory].
	(w _ self currentWorld) ifNotNil:[^w commandHistory].
	^CommandHistory new. "won't really record anything but prevent breaking things"