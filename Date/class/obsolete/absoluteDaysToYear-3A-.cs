absoluteDaysToYear: gregorianYear
	"Computes the number of days from (or until) January 1 of the year 1 A.D. upto (or since) January 1 of a given year. [Alan Lovejoy]"

	| days yearDelta quadCenturies centuries quadYears years isInADEra |
	days := 0.
	isInADEra := gregorianYear > 0.

	gregorianYear = 0 ifTrue: [gregorianYear = -1]. "There is no year 0"
	isInADEra
		ifTrue: [yearDelta := gregorianYear - 1]
		ifFalse: [yearDelta := (gregorianYear + 1) negated].
	quadCenturies := yearDelta // 400.
	yearDelta := yearDelta rem: 400.
	centuries := yearDelta // 100.
	yearDelta := yearDelta rem: 100.
	quadYears := yearDelta // 4.
	years := yearDelta rem: 4.
	days := (quadCenturies * 146097 "days per quad century") +
		(centuries * 36524 "days per century")  +
		(quadYears * 1461 "days per quad year") +
		(years * 365).
	isInADEra ifFalse:
			[days := days + 366.  "1 B.C. is a leap year"
			days := days negated].
	^ days