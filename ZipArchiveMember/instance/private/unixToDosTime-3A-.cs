unixToDosTime: unixTime
	| dosTime dateTime secs |
	secs _ self unixToSqueakTime: unixTime.	"Squeak time (PST?)"
	dateTime _ Time dateAndTimeFromSeconds: secs.
	dosTime _ (dateTime second seconds) bitShift: -1.
	dosTime _ dosTime + ((dateTime second minutes) bitShift: 5).
	dosTime _ dosTime + ((dateTime second hours) bitShift: 11).
	dosTime _ dosTime + ((dateTime first dayOfMonth) bitShift: 16).
	dosTime _ dosTime + ((dateTime first monthIndex) bitShift: 21).
	dosTime _ dosTime + (((dateTime first year) - 1980) bitShift: 25).
	^dosTime
