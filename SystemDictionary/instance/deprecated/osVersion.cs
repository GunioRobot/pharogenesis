osVersion
	"Return the version number string of the platform we're running on"

	self deprecated: 'Use SmalltalkImage current osVersion'.
	^(self getSystemAttribute: 1002) asString