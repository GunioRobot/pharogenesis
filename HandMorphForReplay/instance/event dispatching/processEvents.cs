processEvents
	"Play back the next event"

	| evt |
	(evt _ recorder nextEventToPlay) ifNil: [^ self].
	evt type = #EOF ifTrue: [recorder pauseIn: self world.  ^ self].
	evt type = #startSound ifTrue: [evt sound play.  recorder synchronize.  ^ self].
	(evt type = #mouseMove and: [lastEvent type = #mouseDown])
		ifTrue: ["Since I will have inserted an extra mouseMove after the
				mouseDown, skip the first one on the tape."
				lastEvent _ evt]
		ifFalse: [self handleEvent: (evt setHand: self)].
