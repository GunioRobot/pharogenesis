chooseLoopStart 

	| bestLoops menu secs choice start |
	possibleLoopStarts ifNil: [
		Utilities
			informUser: 'Finding possible loop points...' translated
			during: [possibleLoopStarts _ self findPossibleLoopStartsFrom: graph cursor]].
	bestLoops _ possibleLoopStarts copyFrom: 1 to: (100 min: possibleLoopStarts size).
	menu _ CustomMenu new.
	bestLoops do: [:entry |
		secs _ ((loopEnd - entry first) asFloat / self samplingRate) roundTo: 0.01.
		menu add: ('{1} cycles; {2} secs' translated format:{entry third. secs}) action: entry].
	choice _ menu startUp.
	choice ifNil: [^ self].
	loopCycles _ choice third.
	start _ self fractionalLoopStartAt: choice first.
	self loopLength: (loopEnd asFloat - start) + 1.0.
