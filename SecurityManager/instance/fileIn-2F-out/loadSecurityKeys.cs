loadSecurityKeys
	"SecurityManager default loadSecurityKeys"
	"Load the keys file for the current user"
	| fd loc file keys |
	self isInRestrictedMode ifTrue:[^self]. "no point in even trying"
	loc _ self secureUserDirectory. "where to get it from"
	loc last = FileDirectory pathNameDelimiter ifFalse:[
		loc _ loc copyWith: FileDirectory pathNameDelimiter.
	].
	fd _ FileDirectory on: loc.
	file _ [fd readOnlyFileNamed: keysFileName] 
			on: FileDoesNotExistException do:[:ex| nil].
	file ifNil:[^self]. "no keys file"
	keys _ Object readFrom: file.
	privateKeyPair _ keys first.
	trustedKeys _ keys last.
	file close.