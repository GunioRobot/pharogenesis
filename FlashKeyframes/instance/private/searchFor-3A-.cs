searchFor: frameNumber
	"Return data from the keyframe list at the given frame number"
	| low high mid kf |
	low _ kfList at: 1.
	high _ kfList at: kfList size.
	"Check if in or before first keyframe interval"
	frameNumber <= low stop ifTrue:[^1].
	"Check if in or after last keyframe interval"
	frameNumber >= high start ifTrue:[^kfList size].
	"Somewhere inbetween 2nd to (n-1)th interval"
	low _ 2. high _ kfList size - 1.
	[mid _ high + low // 2.
	low > high] whileFalse:[
		kf _ kfList at: mid.
		(kf includesFrame: frameNumber) ifTrue:[^mid].
		(kf start < frameNumber)
			ifTrue:[low _ mid + 1]
			ifFalse:[high _ mid - 1]].
	kf _ kfList at: low.
	(kf includesFrame: frameNumber) ifFalse:[self error:'No keyframe found'].
	^low