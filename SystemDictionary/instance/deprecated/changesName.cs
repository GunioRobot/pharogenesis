changesName
	"Answer the local name for the changes file corresponding to the image file name."
	"Smalltalk changesName"

	| imName |
	self deprecated: 'Use SmalltalkImage current changesName'.
	imName _ FileDirectory baseNameFor:
		(FileDirectory localNameFor: SmalltalkImage current imageName).
	^ imName, FileDirectory dot, 'changes'
