goToTime: scoreTime

	| track trackSize index newLeftEdgeTime |
	newLeftEdgeTime _ scoreTime asInteger.
	newLeftEdgeTime < leftEdgeTime
		ifTrue: [indexInTrack _ Array new: score tracks size+1 withAll: 1].
	leftEdgeTime _ newLeftEdgeTime.
	1 to: score tracks size do: [:trackIndex |
		track _ score tracks at: trackIndex.
		index _ indexInTrack at: trackIndex.
		trackSize _ track size.
		[(index < trackSize) and:
		 [(track at: index) endTime < leftEdgeTime]]
			whileTrue: [index _ index + 1].
		indexInTrack at: trackIndex put: index].
	self addNotes.
