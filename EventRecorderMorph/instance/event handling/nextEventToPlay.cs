nextEventToPlay
	"Return the next event when it is time to be replayed.
	If it is not yet time, then return an interpolated mouseMove.
	Return nil if nothing has happened.
	Return an EOF event if there are no more events to be played."

	| nextEvent nextAssn nextTime now lastP delta |
	tapeStream atEnd ifTrue: [^ MorphicEvent basicNew
						setType: #EOF cursorPoint: 0@0
						buttons: 0 keyValue: 0].
	nextAssn _ tapeStream next.
	nextEvent _ nextAssn value.
	nextTime _ time + nextAssn key.
	now _ Time millisecondClockValue.
	now < time ifTrue:
		["If the ms clock wraps, simply jump to next event"
		nextTime _ now].
	now >= nextTime
	ifTrue: ["It's time to play the next event"
			time _ nextTime.
			lastDelta _ 0@0.
			^ lastEvent _ nextEvent]
	ifFalse: [tapeStream skip: -1.
			"Not time for the next event yet, but interpolate the mouse.
			This allows tapes to be compressed when velocity is fairly constant."
			lastEvent ifNil: [^ nil].
			lastP _ lastEvent cursorPoint.
			delta _ (nextEvent cursorPoint - lastP) * (now-time) // (nextTime-time).
			delta = lastDelta ifTrue: [^ nil]. "No movement"
			lastDelta _ delta.
			^ MorphicEvent basicNew
					setType: #mouseMove cursorPoint: lastP + delta
					buttons: lastEvent buttons keyValue: 0]
