triggerHaloFor: aMorph after: timeOut
	"Trigger automatic halo after the given time out for some morph"
	self addAlarm: #spawnHaloFor: with: aMorph after: timeOut.