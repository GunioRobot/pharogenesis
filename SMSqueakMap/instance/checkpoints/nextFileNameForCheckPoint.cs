nextFileNameForCheckPoint
	"Return the next available filename for a checkpoint."

	^self directory nextNameFor: self filename extension: self extension