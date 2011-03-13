handleListenEvent: anEvent
	"Record the given event"
	(state == #record and:[anEvent hand == recHand]) 
		ifFalse:[^self].
	anEvent = lastEvent ifTrue: [^ self].
	(anEvent isKeyboard and:[anEvent keyValue = 27 "esc"])
		ifTrue: [^ self stop].
	time _ anEvent timeStamp.
	tapeStream nextPut: (anEvent copy setHand: nil).
	journalFile ifNotNil:
		[journalFile store: anEvent; cr; flush].
	lastEvent _ anEvent.