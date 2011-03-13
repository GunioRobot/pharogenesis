dateAndTimeStringFrom: totalSeconds

	| dateAndTime |
	dateAndTime _ Time dateAndTimeFromSeconds: totalSeconds.
	^dateAndTime first printString,' ',dateAndTime second printString