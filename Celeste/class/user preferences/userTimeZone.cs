userTimeZone
	"Answer the user's timezone string to be used when sending messages."

	TimeZone isEmptyOrNil ifTrue: [self setTimeZone].
	^ TimeZone ifNil: ['']