moveCategoryWithId: anIdString toParentWithId: parentIdString
	"Move a category to another parent.
	If parentIdString is nil then we move it up as a top category."

	| cat parent |
	cat _ self categoryWithId: anIdString.
	parentIdString
		ifNil: [cat parent removeCategory: cat.
			"topCategories add: cat"]
		ifNotNil: [
			parent _ self categoryWithId: parentIdString.
			parent addCategory: cat.
			"topCategories remove: cat ifAbsent: [nil]"]
