updateTargetAt: mSecs
	"Update the volume envelope slope and limit for my target. Answer false."

	mSecs < nextRecomputeTime ifTrue: [^ false].
	self computeSlopeAtMSecs: mSecs.
	target adjustVolumeTo: targetVol * scale overMSecs: mSecsForChange.
	^ false
