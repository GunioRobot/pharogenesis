pathNameDelimiter
	"separator on that remote server.  How tell??"

	type == #ftp ifTrue: [^ $/].
	^ $/