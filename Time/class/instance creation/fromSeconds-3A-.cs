fromSeconds: secondCount 
	"Answer an instnace of me that is secondCount number of seconds since midnight."
	| secondsInHour hours secs |
	secs _ secondCount asInteger.
	hours _ secs // 3600.
	secondsInHour _ secs \\ 3600.
	^self new hours: hours
			   minutes: secondsInHour // 60
			   seconds: secondsInHour \\ 60