processEventsAtTick: scoreTicks

	| instr j snd |
	1 to: score tracks size do: [:i |
		instr _ instruments at: i.
		j _ trackEventIndex at: i.
		[snd _ score soundForTrack: i
			after: j
			ticks: scoreTicks
			instrument: instr
			secsPerTick: secsPerTick.
		 snd ~~ nil]
			whileTrue: [
				(muted at: i)
					ifFalse: [activeSounds add: (Array with: snd with: i)].
				j _ j + 1.
				trackEventIndex at: i put: j]].
