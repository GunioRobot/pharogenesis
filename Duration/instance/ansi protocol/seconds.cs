seconds
	"Answer the number of seconds the receiver represents."

	^ (seconds rem: SecondsInMinute) + (nanos / NanosInSecond)