convertV0Tape: anArray
	"Convert the tape into the new format"
	| lastKey evt |
	lastKey _ 0.
	^anArray collect:[:assn| 
		evt _ assn value.
		evt setTimeStamp: (lastKey _ lastKey + assn key).
		evt]