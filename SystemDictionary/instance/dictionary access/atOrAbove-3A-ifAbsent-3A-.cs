atOrAbove: key ifAbsent: absentBlock
	"Compatibility with environment protocol."

	^ self at: key ifAbsent: absentBlock