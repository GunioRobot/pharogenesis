cleanseStepListForWorld: aWorld
	"Remove morphs from the step list that are not in this World.  Often were in a flap that has moved on to another world."

	| deletions morphToStep |
	deletions _ nil.
	stepList do: [:entry |
		morphToStep _ entry receiver.
		morphToStep world == aWorld ifFalse:[
			deletions ifNil: [deletions _ OrderedCollection new].
			deletions addLast: entry]].

	deletions ifNotNil:[
		deletions do: [:entry|
			self stopStepping: entry receiver]].

	self alarms copy do:[:entry|
		morphToStep _ entry receiver.
		(morphToStep isMorph and:[morphToStep world == aWorld]) 
			ifFalse:[self removeAlarm: entry selector for: entry receiver]].