systemInformationString
	"Identify software version"
	^ SystemVersion current version, String cr, self lastUpdateString, String cr, self currentChangeSetString

"
	(eToySystem _ self at: #EToySystem ifAbsent: [nil]) ifNotNil:
		[aString _ aString, '
Squeak-Central version: ', eToySystem version, ' of ', eToySystem versionDate]."