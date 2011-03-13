condense
	"Shorten the tape by deleting mouseMove events that can just as well be
	interpolated later at playback time."
	| e1 e2 t1 t2 e3 t3 |
	"e1, e2, and e3 are three consecutive events on the tape.
	t1, t2, and t3 are the associated time steps for each of them."
	tape _ Array streamContents:
	[:tStream |
	e1 _ e2 _ e3 _ nil.  t1 _ t2 _ t3 _ nil.
	1 to: tape size do:[:i|
		e1 _ e2.  t1 _ t2.
		e2 _ e3.  t2 _ t3.
		e3 _ tape at: i. t3 _ e3 timeStamp.
		((e1 ~~ nil and: [(e2 type == #mouseMove) &
				(e1 type == #mouseMove or: [e3 type == #mouseMove])]) and: 
			["Middle point within 3 pixels of mean of outer two"
			e2 position onLineFrom: e1 position to: e3 position within: 2.5])
			ifTrue: ["Delete middle mouse move event.  Absorb its time into e3"
					e2 _ e1.  t2 _ t1]
			ifFalse: [e1 ifNotNil: [tStream nextPut: (e1 copy setTimeStamp: t1)]]].
	e2 ifNotNil: [tStream nextPut: (e2 copy setTimeStamp: t2)].
	e3 ifNotNil: [tStream nextPut: (e3 copy setTimeStamp: t3)]].
