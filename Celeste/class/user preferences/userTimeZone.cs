userTimeZone
	"Answer the user's timezone string to be used when sending messages."

	TimeZoneString isEmptyOrNil ifTrue: [self setTimeZone].
	^ TimeZoneString ifNil: ['']