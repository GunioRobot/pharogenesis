nextEventToPlay
	"Return the next event when it is time to be replayed.
	If it is not yet time, then return an interpolated mouseMove.
	Return nil if nothing has happened.
	Return an EOF event if there are no more events to be played."
	| nextEvent now nextTime lastP delta |
	(tapeStream isNil or:[tapeStream atEnd]) 
		ifTrue:[^MorphicUnknownEvent new setType: #EOF argument: nil].
	now _ Time millisecondClockValue.
	nextEvent _ tapeStream next.
	nextEvent isKeyboard ifTrue: [ nextEvent setPosition: self position ].
	deltaTime ifNil:[deltaTime _ now - nextEvent timeStamp].
	nextTime _ nextEvent timeStamp + deltaTime.
	now < time ifTrue:["clock rollover"
		time _ now.
		deltaTime _ nil.
		^nil "continue it on next cycle"].
	time _ now.
	(now >= nextTime) ifTrue:[
		nextEvent _ nextEvent copy setTimeStamp: nextTime.
		nextEvent isMouse ifTrue:[lastEvent _ nextEvent] ifFalse:[lastEvent _ nil].
		^nextEvent].
	tapeStream skip: -1.
	"Not time for the next event yet, but interpolate the mouse.
	This allows tapes to be compressed when velocity is fairly constant."
	lastEvent ifNil: [^ nil].
	lastP _ lastEvent position.
	delta _ (nextEvent position - lastP) * (now - lastEvent timeStamp) // (nextTime - lastEvent timeStamp).
	delta = lastDelta ifTrue: [^ nil]. "No movement"
	lastDelta _ delta.
	^MouseMoveEvent new
		setType: #mouseMove 
		startPoint: lastEvent position endPoint: lastP + delta
		trail: #() buttons: lastEvent buttons hand: nil stamp: now.