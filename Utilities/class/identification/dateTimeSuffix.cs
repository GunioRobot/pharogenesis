dateTimeSuffix
	"Answer a string which indicates the date and time, intended for use in building fileout filenames, etc.  1/18/96 sw"

	"Utilities dateTimeSuffix"

	| dateTime headString tailString |
	dateTime _ Time dateAndTimeNow.
	headString _ dateTime first printString copyFrom: 1 to: 6.
	headString _ headString copyWithout: $ .
	tailString _ dateTime last printString copyWithout: $:.
	^ headString, (tailString copyFrom: 1 to: tailString size - 5), (tailString copyFrom: tailString size -1 to: tailString size)