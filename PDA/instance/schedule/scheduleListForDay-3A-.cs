scheduleListForDay: aDate

	| dayList |
	dayList _ ((allEvents select: [:c | c matchesKey: 'all' andMatchesDate: aDate])
			, ((recurringEvents select: [:c | c matchesKey: 'all' andMatchesDate: aDate])
					collect: [:re | (re as: PDAEvent) date: aDate])) sort.
	^ dayList collect: [:evt | evt asListItem]