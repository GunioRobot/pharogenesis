serverDelimiter
	"the separator that is used in the place where the file actually is.  ftp server or local disk."

	^ type == #file: ifTrue: [FileDirectory default pathNameDelimiter]
		ifFalse: [^ $/]	"for ftp, http"