regressionTestFrom: fd
	"ZipWriteStream regressionTestFrom: FileDirectory default"
	"ZipWriteStream regressionTestFrom: (FileDirectory on:'')"
	"ZipWriteStream regressionTestFrom: (FileDirectory on:'C:')"
	| tempName stats |
	Transcript clear.
	stats _ Dictionary new.
	tempName _ FileDirectory default fullNameFor: '$$sqcompress$$'.
	FileDirectory default deleteFileNamed: tempName.
	self regressionTestFrom: fd using: tempName stats: stats.