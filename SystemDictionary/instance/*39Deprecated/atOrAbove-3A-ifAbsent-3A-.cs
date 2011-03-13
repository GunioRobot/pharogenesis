atOrAbove: key ifAbsent: absentBlock
	"Compatibility with environment protocol."

	self deprecated: 'use at:ifAbsent:'.
	^ self at: key ifAbsent: absentBlock