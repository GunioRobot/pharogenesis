includesKeyOrAbove: key
	"Compatibility with environment protocol."

	self atOrAbove: key ifAbsent: [^ false].
	^ true