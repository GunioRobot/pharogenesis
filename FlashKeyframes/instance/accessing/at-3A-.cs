at: frameNumber
	"Return data from the keyframe list at the given frame number"
	| lastEntry |
	kfList isEmpty ifTrue:[^nil].
	lastIndex ifNil:[lastIndex _ self searchFor: frameNumber].
	lastEntry _ kfList at: lastIndex.
	(lastEntry includesFrame: frameNumber) ifTrue:[^lastEntry data].
	"Do a quick check if the frame is out of range"
	kfList first stop >= frameNumber 
		ifTrue:[	lastIndex _ 1.
				^kfList first data].
	kfList last start <= frameNumber 
		ifTrue:[	lastIndex _ kfList size. 
				^kfList last data].

	"Search linearly from lastEntry - most times we'll just be one step away"
	[lastEntry stop >= frameNumber] whileFalse:[
		lastIndex _ lastIndex+1.
		lastEntry _ kfList at: lastIndex].
	[lastEntry start <= frameNumber] whileFalse:[
		lastIndex _ lastIndex-1.
		lastEntry _ kfList at: lastIndex].
	^lastEntry data