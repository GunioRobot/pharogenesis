timeStamp: aStream 
	"Writes system version and current time on stream aStream."

	| dateTime |
	dateTime := Time dateAndTimeNow.
	aStream nextPutAll: 'From ', SmalltalkImage current datedVersion, ' [', SmalltalkImage current lastUpdateString, '] on ', (dateTime at: 1) printString,
						' at ', (dateTime at: 2) printString