now
	"Answer a Time representing the time right now - this is a 24 hour clock."

	| ms |
	
	ms := self milliSecondsSinceMidnight.

	^ self seconds:  (ms // 1000) nanoSeconds: (ms \\ 1000) * 1000000


