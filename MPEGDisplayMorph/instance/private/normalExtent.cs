normalExtent
	"private - answer the extent of the video, if any"
	(mpegFile isNil
			or: [mpegFile hasVideo not])
		ifTrue: [^ nil].
	""
	^ (mpegFile videoFrameWidth: 0)
		@ (mpegFile videoFrameHeight: 0)