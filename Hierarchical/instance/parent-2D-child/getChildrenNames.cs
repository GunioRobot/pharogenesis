getChildrenNames
	"Return the object's children."

	^ myChildren collect: [: child | child asString ].
