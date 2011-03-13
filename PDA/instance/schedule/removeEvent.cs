removeEvent

	(currentItem isKindOf: PDARecurringEvent)
	ifTrue: [(self confirm:
'Rather than remove a recurring event, it is
better to declare its last day to keep the record.
Do you still wish to remove it?')
				ifFalse: [^ self].
			recurringEvents _ recurringEvents copyWithout: currentItem]
	ifFalse: [allEvents _ allEvents copyWithout: currentItem].
	self currentItem: nil.
	self updateScheduleList.
