localTimeZone
	"Answer the local time zone"

	^ LocalTimeZone ifNil: [ LocalTimeZone _ TimeZone default ]

