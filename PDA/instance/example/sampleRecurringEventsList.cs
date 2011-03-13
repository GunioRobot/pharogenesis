sampleRecurringEventsList

	^ {
	PDARecurringEvent new key: 'home'; description: 'take out trash'; recurrence: #dayOfWeek; firstDate: (Date readFromString: '7 September 1999').
	PDARecurringEvent new key: 'home'; description: 'pay bills'; recurrence: #dayOfMonth; firstDate: (Date readFromString: '1 September 1999').
	PDARecurringEvent new key: 'all'; description: 'Columbus Day'; recurrence: #dateOfYear; firstDate: (Date readFromString: '12 October 1999').
	PDARecurringEvent new key: 'all'; description: 'Christmas'; recurrence: #dateOfYear; firstDate: (Date readFromString: '25 December 1999').
	PDARecurringEvent new key: 'all'; description: 'New Years'; recurrence: #dateOfYear; firstDate: (Date readFromString: '1 January 1999').
	PDARecurringEvent new key: 'all'; description: 'April Fools Day'; recurrence: #dateOfYear; firstDate: (Date readFromString: '1 April 1999').
	PDARecurringEvent new key: 'all'; description: 'Independence Day'; recurrence: #dateOfYear; firstDate: (Date readFromString: '4 July 1999').
	PDARecurringEvent new key: 'all'; description: 'Thanksgiving Day'; recurrence: #nthWeekdayOfMonthEachYear; firstDate: (Date readFromString: '25 November 1999').
	}