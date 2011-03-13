mouseTrailFrom: currentBuf
	"Current event, a mouse event buffer, is about to be processed.  If there are other similar mouse events queued up, then drop them from the queue, and report the positions inbetween."
	| nextEvent trail |
	trail _ WriteStream on: (Array new: 1).
	trail nextPut: ((currentBuf at: 3) @ (currentBuf at: 4)).
	[(nextEvent _ Sensor peekEvent) == nil] whileFalse:[
		(nextEvent at: 1) = (currentBuf at: 1) ifFalse:
			[^ trail contents  "different event type"].
		(nextEvent at: 5) = (currentBuf at: 5) ifFalse:
			[^ trail contents  "buttons changed"].
		(nextEvent at: 6) = (currentBuf at: 6) ifFalse:
			[^ trail contents  "modifiers changed"].
		"nextEvent is similar.  Remove it from the queue, and check the next."
		nextEvent _ Sensor nextEvent.
		trail nextPut: ((nextEvent at: 3) @ (nextEvent at: 4))
	].
	^trail contents