layoutChanged
	"Note that something has changed about the size, shape, or location of the receiver or one of its submorphs, so that fullBounds must be recomputed."

	fullBounds _ nil.
	owner ifNotNil: [owner layoutChanged].
	submorphs size > 0 ifTrue:
		["Let submorphs know about a change above"
		submorphs do: [:m | m ownerChanged]].
