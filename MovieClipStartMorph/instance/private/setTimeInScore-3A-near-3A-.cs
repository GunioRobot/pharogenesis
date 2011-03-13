setTimeInScore: score near: dropTime
	"Find a time to place this clip that does not overlap other clips.
	So, if I start in the middle of another clip, move me to the end of it,
	and if I start very soon after another clip, put me right at the end.
	Then, if my end goes beyond the start of another clip, shorten me
	so I end right before that clip."

	| startTime endTime delta endFrame |
	startTime := dropTime.
	endMorph ifNil: [endFrame := moviePlayerMorph frameCount]
			ifNotNil: [endFrame := endMorph frameNumber].
	endTime := startTime   "in ticks"
		+ (movieClipPlayer pianoRoll scorePlayer ticksForMSecs:
			(endFrame - frameNumber)
			* moviePlayerMorph msPerFrame).
	score eventMorphsDo:
		[:m | (m ~~ self and: [m isMemberOf: self class]) ifTrue:
				[((startTime between: m startTime and: m endTime)
					or: [startTime between: m endTime and: m endTime+50])
					ifTrue: ["If I start in the middle of another clip, or a little
							past its end, move me exactly to the end of it"
							delta := (m endTime + 1) - startTime.
							startTime := startTime + delta.
							endTime := endTime + delta].
				(endTime between: m startTime and: m endTime)
					ifTrue: ["If my end goes overlaps another clip, shorten me so I fit."
							endTime := m startTime - 1].
				]].
	scoreEvent time: startTime.
	score removeAmbientEventWithMorph: self;
			addAmbientEvent: scoreEvent.
	self setEndFrameNumber: endFrame tickTime: endTime.
