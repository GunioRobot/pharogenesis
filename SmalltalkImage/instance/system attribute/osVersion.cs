osVersion
	"Return the version number string of the platform we're running on"

	^(self getSystemAttribute: 1002) asString