platformSubtype
	"Return the subType of the platform we're running on"

	self deprecated: 'Use SmalltalkImage current platformSubtype'.
	^self getSystemAttribute: 1003