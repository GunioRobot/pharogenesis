= another

	"Use == between two symbols..."
	self == another ifTrue: [^ true].  "Was == "
	another class == MultiSymbol ifTrue: [^ false].  "Was not == "

	"Otherwise use string =..."
	^ super = another.
