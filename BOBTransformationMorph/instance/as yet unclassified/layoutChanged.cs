layoutChanged

	| myGuy |
	"use the version from Morph"

	fullBounds _ nil.
	owner ifNotNil: [owner layoutChanged].
	submorphs size > 0 ifTrue: [
		(myGuy _ self firstSubmorph) isWorldMorph ifFalse: [
			worldBoundsToShow = myGuy bounds ifFalse: [
				self changeWorldBoundsToShow: (worldBoundsToShow _ myGuy bounds).
			].
		].

		"submorphs do: [:m | m ownerChanged]"		"<< I don't see any reason for this"
	].
