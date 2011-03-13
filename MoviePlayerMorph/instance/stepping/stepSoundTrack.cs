stepSoundTrack

	| x image timeInMillisecs |
	scorePlayer ifNil: [^ self].
	soundTrackForm ifNil: [^ self].
	playDirection = 0
		ifTrue: ["Stepping forward or back"
				timeInMillisecs _ frameNumber - 1 * msPerFrame]
		ifFalse: ["Driven by sound track"
				timeInMillisecs _ scorePlayer millisecondsSinceStart].
	x _ timeInMillisecs / 1000.0 * scorePlayer originalSamplingRate // 250.
	image _ soundTrackMorph image.
	image copy: (image boundingBox translateBy: (x - (image width//2)) @ 0)
			from: soundTrackForm to: 0@0 rule: Form over.
	soundTrackMorph changed.