handleSignificantEvent: newEvent 
	| now |
	state == #record ifFalse: [^ self].
	newEvent hand == recHand ifFalse: [^ self].
	newEvent keyCharacter = (Character value: 27 "esc")
		ifTrue: [^ self stop].
	now _ Time millisecondClockValue.
	now < time ifTrue:
		["If the ms clock wraps, output a small delta"
		time _ now-10].
	tapeStream nextPut: (now - time) -> newEvent.
	journalFile ifNotNil:
		[journalFile store: (now - time); space; store: newEvent; cr; flush].
"
Transcript cr; print: ((now - time) -> newEvent); endEntry.
"
	lastEvent _ newEvent.
	time _ now.