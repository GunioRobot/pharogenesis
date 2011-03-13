setEndFrameNumber: frameOrNil tickTime: timeOrNil
	"May be called with either time or frame being nil,
	in which case the other will br computed."

	| pianoRoll frame time |
	pianoRoll _ movieClipPlayer pianoRoll.
	frame _ frameOrNil ifNil:
		[frameNumber + 
			((timeOrNil - self startTime)
			* (pianoRoll scorePlayer secsPerTick*1000.0)
			/ moviePlayerMorph msPerFrame) asInteger - 1].
	time _ timeOrNil ifNil:
		[self startTime +   "in ticks"
			(pianoRoll scorePlayer ticksForMSecs:
			(frameOrNil - frameNumber) * moviePlayerMorph msPerFrame)].
	endMorph ifNil:
		[endMorph _ MovieClipEndMorph new
			movieFileName: movieClipFileName
			image: (moviePlayerMorph pageFormForFrame: frame)
			player: movieClipPlayer
			frameNumber: frame]
		ifNotNil:
		[endMorph image: (moviePlayerMorph pageFormForFrame: frame)
			frameNumber: frame].

	endMorph scoreEvent time: time.
	pianoRoll score removeAmbientEventWithMorph: endMorph;
		addAmbientEvent: endMorph scoreEvent.
	soundTrackMorph _ nil.  "Force it to be recomputed."
	pianoRoll rebuildFromScore
