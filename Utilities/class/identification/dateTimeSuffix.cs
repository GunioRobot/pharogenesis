dateTimeSuffix
	"Answer a string which indicates the date and time, intended for use in building fileout filenames, etc."

	"Utilities dateTimeSuffix"
	^ Preferences twentyFourHourFileStamps
		ifFalse:
			[self monthDayTimeStringFrom: Time primSecondsClock]
		ifTrue:
			[self monthDayTime24StringFrom: Time primSecondsClock]