subBounds
	"calculate the submorph bounds"
	| subBounds |
	subBounds _ nil.
	self submorphsDo:
		[:m | subBounds == nil
			ifTrue: [subBounds _ m fullBounds]
			ifFalse: [subBounds _ subBounds merge: m fullBounds]].
	^ subBounds