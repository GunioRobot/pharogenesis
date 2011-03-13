localOffset
	"Answer the duration we are offset from UTC"

	^ LocalOffset ifNil:[ LocalOffset := self localTimeZone offset ]
