name: varName index: i type: type scope: level
	"Only used for initting temporary variables"
	self name: varName.
	self key: varName
		index: i
		type: type.
	self isArg: (hasDefs _ hasRefs _ false).
	self scope: level