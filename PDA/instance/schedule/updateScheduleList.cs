updateScheduleList
	(date isNil
			and: [category ~= 'recurring'])
		ifTrue: [scheduleList _ Array new.
			scheduleListIndex _ 0.
			^ self changed: #scheduleListItems].
	scheduleList _ (category = 'recurring'
				ifTrue: ["When 'recurring' is selected, edit actual masters"
					(recurringEvents
						select: [:c | c matchesKey: category andMatchesDate: date]) ]
				ifFalse: ["Otherwise, recurring events just spawn copies."
					((allEvents
						select: [:c | c matchesKey: category andMatchesDate: date])
						, ((recurringEvents
								select: [:c | c matchesKey: category andMatchesDate: date])
								collect: [:re | (re as: PDAEvent)
										date: date])) ])sort.
	scheduleListIndex _ scheduleList indexOf: currentItem.
	self changed: #scheduleListItems