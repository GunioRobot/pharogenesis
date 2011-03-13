renameActionsWithReceiver: anObject forEvent: anEventSelector toEvent: newEvent

	| oldActions newActions |
	oldActions _ Set new.
	newActions _ Set new.
	(self actionSequenceForEvent: anEventSelector) do: [ :action |
		action receiver == anObject
			ifTrue: [ oldActions add: anObject ]
			ifFalse: [ newActions add: anObject ]].
	self setActionSequence: (ActionSequence withAll: newActions) forEvent: anEventSelector.
	oldActions do: [ :act | self when: newEvent evaluate: act ].