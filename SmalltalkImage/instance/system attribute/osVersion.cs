osVersion
	"Return the version number string of the platform we're running on"
	"SmalltalkImage current osVersion"

	^(self getSystemAttribute: 1002) asString