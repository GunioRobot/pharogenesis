changesName
	"Answer the local name for the changes file corresponding to the image file name."
	"Smalltalk changesName"

	| imName |
	imName := FileDirectory baseNameFor:
		(FileDirectory localNameFor: self imageName).
	^ imName, FileDirectory dot, 'changes'