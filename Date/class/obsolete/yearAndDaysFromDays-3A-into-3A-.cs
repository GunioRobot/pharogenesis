yearAndDaysFromDays: days into: aTwoArgBlock
	"Compute the Gregorian year, and the day of the year, from the number of days since (or until) January 1 of the year 1 A.D. Return the values in a block.  [Alan Lovejoy]"

	| quadCentury year dayInYear isInADEra century quadYear |
	dayInYear := days.
	isInADEra := days >= 0.

	isInADEra
		ifTrue: [year := 0]
		ifFalse: [dayInYear := dayInYear abs.
			dayInYear >= 366 "days per leap year" 
				ifTrue: [year := 1.
						dayInYear := dayInYear - 366]	"Subtract the year 1 B.C."
				ifFalse: [year := 0]].

	quadCentury := dayInYear // 146097 "days per quad century".
	dayInYear := dayInYear \\ 146097 "days per quad century".
	century := dayInYear // 36524 "days per century".
	dayInYear := dayInYear \\ 36524 "days per century".
	quadYear := dayInYear // 1461 "days per quad year".
	dayInYear := dayInYear \\ 1461 "days per quad year".
	dayInYear >= 365 "days per standard year" ifTrue: ["e.g., 1 AD or 2 BC"
		dayInYear := dayInYear - 365 "days per standard year".
		year := year + 1.
		dayInYear >= 365 "days per standard year" ifTrue: ["e.g., 2 AD or 3 BC"
			dayInYear := dayInYear - 365 "days per standard year".
			year := year + 1.
			dayInYear >= 365 "days per standard year" ifTrue: ["e.g., 3 AD or 4 BC"
				dayInYear := dayInYear - 365 "days per standard year".
				year := year + 1.
				dayInYear >= 366 "days per leap year" ifTrue: [
					"e.g., 4 AD or 5 BC (although this won't occur in the AD case)"
					dayInYear := dayInYear - 366 "days per leap year".
					year := year + 1]]]].

	year := year + (quadCentury * 400) + (century * 100) + (quadYear * 4) + 1.
	isInADEra ifFalse: [
		year := year negated.
		dayInYear > 0 ifTrue: [
			(Date leapYear: year) = 1
				ifTrue: [dayInYear := 366 "days per leap year" - dayInYear]
				ifFalse: [dayInYear := 365 "days per standard year" - dayInYear]]].
	^ aTwoArgBlock value: year value: dayInYear+1 "the way Dates do it"