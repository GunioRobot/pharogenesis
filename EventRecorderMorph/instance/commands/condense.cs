condense
	"Shorten the tape by deleting mouseMove events that can just as well be
	interpolated later at playback time."
	| e1 e2 dt1 dt2 e3 dt3 |
	"e1, e2, and e3 are three consecutive events on the tape.
	dt1, dt2, and dt3 are the associated time steps for each of them."
	tape _ Array streamContents:
	[:tStream |
	e1 _ e2 _ e3 _ nil.  dt1 _ dt2 _ dt3 _ nil.
	tape do:
		[:a | 
		e1 _ e2.  dt1 _ dt2.
		e2 _ e3.  dt2 _ dt3.
		e3 _ a value.  dt3 _ a key.
		((e1 ~~ nil and: [(e2 type == #mouseMove) &
				(e1 type == #mouseMove or: [e3 type == #mouseMove])]) and: 
			["Middle point within 3 pixels of mean of outer two"
			e2 cursorPoint onLineFrom: e1 cursorPoint to: e3 cursorPoint within: 2.5])
			ifTrue: ["Delete middle mouse move event.  Absorb its time into e3"
					dt3 _ dt2 + dt3.  
					e2 _ e1.  dt2 _ dt1]
			ifFalse: [e1 ifNotNil: [tStream nextPut: dt1 -> e1]]].
	e2 ifNotNil: [tStream nextPut: dt2 -> e2].
	e3 ifNotNil: [tStream nextPut: dt3 -> e3]].
