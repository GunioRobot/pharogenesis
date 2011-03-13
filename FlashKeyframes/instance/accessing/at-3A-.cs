at: frameNumber
	"Return data from the keyframe list at the given frame number"
	| lastEntry |
	kfList isEmpty ifTrue:[^nil].
	lastIndex ifNil:[lastIndex := self searchFor: frameNumber].
	lastEntry := kfList at: lastIndex.
	(lastEntry includesFrame: frameNumber) ifTrue:[^lastEntry data].
	"Do a quick check if the frame is out of range"
	kfList first stop >= frameNumber 
		ifTrue:[	lastIndex := 1.
				^kfList first data].
	kfList last start <= frameNumber 
		ifTrue:[	lastIndex := kfList size. 
				^kfList last data].

	"Search linearly from lastEntry - most times we'll just be one step away"
	[lastEntry stop >= frameNumber] whileFalse:[
		lastIndex := lastIndex+1.
		lastEntry := kfList at: lastIndex].
	[lastEntry start <= frameNumber] whileFalse:[
		lastIndex := lastIndex-1.
		lastEntry := kfList at: lastIndex].
	^lastEntry data