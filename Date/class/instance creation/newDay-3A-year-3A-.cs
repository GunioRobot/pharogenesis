newDay: dayCount year: referenceYear 
	"Answer an instance of me which is dayCount days after the beginning of the year referenceYear."

	| day year daysInYear date |
	day _ dayCount.
	year _ referenceYear.
	[ day > (daysInYear _ self daysInYear: year) ] whileTrue: 
	[
		year _ year + 1.
		day _ day - daysInYear
	].

	[ day <= 0 ] whileTrue: 
	[
		year _ year - 1.
		day _ day + (self daysInYear: year)
	].
	
	date _ self newDay: 1 month: 1 year: year.
	^date addDays: (day - 1).
