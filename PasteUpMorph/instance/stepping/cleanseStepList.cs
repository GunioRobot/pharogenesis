cleanseStepList
	"Remove morphs from the step list that are not in this World.  Often were in a flap that has moved on to another world."

	| deletions morphToStep |
	deletions _ nil.
	self stepList do: [:entry |
		morphToStep _ entry at: 1.
		morphToStep world == self
			ifFalse:
				[deletions ifNil: [deletions _ OrderedCollection new].
				deletions addLast: morphToStep]].

	deletions ifNotNil:
		[deletions do: [:deletedM |
			self stopStepping: deletedM.
			deletedM stopStepping]].

