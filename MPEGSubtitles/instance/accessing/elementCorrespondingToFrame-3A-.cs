elementCorrespondingToFrame: frameNumber 
	"answer the element corresponding to frameNumber"
	^ elements
		detect: [:each | each correspondsToFrame: frameNumber]
		ifNone: []