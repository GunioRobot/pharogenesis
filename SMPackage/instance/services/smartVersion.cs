smartVersion
	"Delegate to last published release for this SystemVersion."

	| r |
	r := self lastPublishedReleaseForCurrentSystemVersion.
	^r ifNotNil: [r smartVersion] ifNil: ['']