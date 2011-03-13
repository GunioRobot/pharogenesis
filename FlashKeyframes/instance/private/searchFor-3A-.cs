searchFor: frameNumber
	"Return data from the keyframe list at the given frame number"
	| low high mid kf |
	low := kfList at: 1.
	high := kfList at: kfList size.
	"Check if in or before first keyframe interval"
	frameNumber <= low stop ifTrue:[^1].
	"Check if in or after last keyframe interval"
	frameNumber >= high start ifTrue:[^kfList size].
	"Somewhere inbetween 2nd to (n-1)th interval"
	low := 2. high := kfList size - 1.
	[mid := high + low // 2.
	low > high] whileFalse:[
		kf := kfList at: mid.
		(kf includesFrame: frameNumber) ifTrue:[^mid].
		(kf start < frameNumber)
			ifTrue:[low := mid + 1]
			ifFalse:[high := mid - 1]].
	kf := kfList at: low.
	(kf includesFrame: frameNumber) ifFalse:[self error:'No keyframe found'].
	^low