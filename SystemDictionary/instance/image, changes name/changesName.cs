changesName
	"Answer the local name for the changes file corresponding to the image file name."
	"Smalltalk changesName"

	| imName ends |
	imName _ FileDirectory localNameFor: self imageName.
	ends _ self fileNameEnds.
	^ (imName copyFrom: 1 to: imName size - ends first size), ends last
