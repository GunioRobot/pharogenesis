storeSecurityKeys
	"SecurityManager default storeSecurityKeys"
	"Store the keys file for the current user"
	| fd loc file |
	self isInRestrictedMode ifTrue:[^self]. "no point in even trying"
	loc _ self secureUserDirectory. "where to put it"
	loc last = FileDirectory pathNameDelimiter ifFalse:[
		loc _ loc copyWith: FileDirectory pathNameDelimiter.
	].
	fd _ FileDirectory on: loc.
	fd assureExistence.
	fd deleteFileNamed: self keysFileName ifAbsent:[].
	file _ fd newFileNamed: self keysFileName.
	{privateKeyPair. trustedKeys} storeOn: file.
	file close.