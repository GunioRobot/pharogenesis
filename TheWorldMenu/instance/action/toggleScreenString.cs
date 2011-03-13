toggleScreenString
	^ Display isFullScreen
		ifFalse: ['Full screen on' translated]
		ifTrue:	['Full screen off' translated]
