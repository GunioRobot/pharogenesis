includesKeyOrAbove: key
	"Compatibility with environment protocol."

	self deprecated: 'use includesKey:'.
	self at: key ifAbsent: [^ false].
	^ true