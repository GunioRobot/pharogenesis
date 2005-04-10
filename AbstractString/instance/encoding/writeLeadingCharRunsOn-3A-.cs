writeLeadingCharRunsOn: stream

	| runLength runValues runStart leadingChar |
	self isEmpty ifTrue: [^ self].

	runLength _ OrderedCollection new.
	runValues _ OrderedCollection new.
	runStart _ 1.
	leadingChar _ (self at: runStart) leadingChar.
	2 to: self size do: [:index |
		(self at: index) leadingChar = leadingChar ifFalse: [
			runValues add: leadingChar.
			runLength add: (index - runStart).
			leadingChar _ (self at: index) leadingChar.
			runStart _ index.
		].
	].
	runValues add: (self last) leadingChar.
	runLength add: self size + 1 -  runStart.

	stream nextPut: $(.
	runLength do: [:rr | rr printOn: stream. stream space].
	stream skip: -1; nextPut: $).
	runValues do: [:vv | vv printOn: stream. stream nextPut: $,].
	stream skip: -1.
