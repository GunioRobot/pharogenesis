name: varName index: i type: type scope: level
	"Only used for initting temporary variables"
	name _ varName.
	self key: varName
		index: i
		type: type.
	isAnArg _ hasDefs _ hasRefs _ false.
	scope _ level