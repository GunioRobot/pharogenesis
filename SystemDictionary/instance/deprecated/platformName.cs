platformName
	"Return the name of the platform we're running on"

	self deprecated: 'Use SmalltalkImage current platformName'.
	^self getSystemAttribute: 1001