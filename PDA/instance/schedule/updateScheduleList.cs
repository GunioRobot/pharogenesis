updateScheduleList

	(date == nil and: [category ~= 'recurring']) ifTrue:
		[scheduleList _ Array new.  scheduleListIndex _ 0.
		^ self changed: #scheduleListItems].
	category = 'recurring'
	ifTrue: ["When 'recurring' is selected, edit actual masters"
			scheduleList _ (recurringEvents select:
				[:c | c matchesKey: category andMatchesDate: date]) sort]
	ifFalse: ["Otherwise, recurring events just spawn copies."
			scheduleList _ ((allEvents select: [:c | c matchesKey: category andMatchesDate: date])
			, ((recurringEvents select: [:c | c matchesKey: category andMatchesDate: date])
					collect: [:re | (re as: PDAEvent) date: date])) sort].
	scheduleListIndex _ scheduleList indexOf: currentItem.
	self changed: #scheduleListItems