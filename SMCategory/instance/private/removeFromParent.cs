removeFromParent
	"Remove me from my parent."

	parent ifNotNil: [parent removeCategory: self]