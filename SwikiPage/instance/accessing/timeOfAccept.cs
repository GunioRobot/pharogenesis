timeOfAccept
	"return the Time when the text was written on the file"

	| theFile pp theReturn |
	theFile _ FileStream oldFileNamed: file.
	theFile setToEnd.
	pp _ self backupAChunk: theFile.
	pp _ pp - 5.		"before the back:"
	theFile upTo: $'; skip: -1.		"name"
	theFile nextDelimited: $'.
	theFile upTo: $'; skip: -1.		"date"
	theFile nextDelimited: $'.
	theFile upTo: $'; skip: -1.		"time"
	theReturn := (theFile nextDelimited: $') asTime.
	theFile close.
	^theReturn
