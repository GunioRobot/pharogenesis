setUp
	restoredStartDay _ Week startDay.
	restoredTimeZone _ DateAndTime localTimeZone.

	Week startDay: #Sunday.
	DateAndTime localTimeZone: (TimeZone timeZones detect: [:tz | tz abbreviation = 'GMT']).