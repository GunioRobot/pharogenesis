moveCategoryWithId: anIdString toAfterWithId: beforeIdString
	"Move a category to be before another category.
	If beforeIdString is nil then we move it up to be first."

	| cat before |
	cat _ self categoryWithId: anIdString.
	before _ beforeIdString ifNotNil: [self categoryWithId: beforeIdString].
	cat parent move: cat toAfter: before