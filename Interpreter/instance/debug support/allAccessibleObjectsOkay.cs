allAccessibleObjectsOkay
	"Ensure that all accessible objects in the heap are okay."

	| oop |
	oop _ self firstAccessibleObject.
	[oop = nil] whileFalse: [
		self okayFields: oop.
		oop _ self accessibleObjectAfter: oop.
	].