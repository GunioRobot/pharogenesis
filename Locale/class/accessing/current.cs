current
	"Current := nil"
	Current ifNil: [Current := self determineCurrentLocale].
	^Current