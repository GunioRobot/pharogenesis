signFile: fileName directory: fileDirectory
	"Sign the given project in the directory"
	| bytes file dsa hash sig key |
	Preferences signProjectFiles ifFalse:[^self]. "signing turned off"
	key _ self signingKey.
	key ifNil:[^self].
	file _ FileStream readOnlyFileNamed: (fileDirectory fullNameFor: fileName).
	bytes _ file binary; contentsOfEntireFile.
	fileDirectory deleteFileNamed: fileName ifAbsent:[].
	dsa _ DigitalSignatureAlgorithm new.
	dsa initRandom: Time millisecondClockValue + Date today julianDayNumber.
	hash _ SecureHashAlgorithm new hashStream: (ReadStream on: bytes).
	sig _ dsa computeSignatureForMessageHash: hash privateKey: key.
	file _ FileStream newFileNamed: (fileDirectory fullNameFor: fileName).
	file binary.
	"store a header identifying the signed file first"
	file nextPutAll: 'SPRJ' asByteArray.
	"now the signature"
	file 
		nextPutAll: (sig first withAtLeastNDigits: 20); 
		nextPutAll: (sig last withAtLeastNDigits: 20).
	"now the contents"
	file nextPutAll: bytes.
	file close.