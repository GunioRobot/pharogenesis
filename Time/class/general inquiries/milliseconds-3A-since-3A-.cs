milliseconds: currentTime since: lastTime
	| delta |
	"Answer the elapsed time since last recorded in milliseconds.
	Compensate for rollover."

	delta _ currentTime - lastTime.
	^delta < 0
		ifTrue: [SmallInteger maxVal + delta]
		ifFalse: [delta]
