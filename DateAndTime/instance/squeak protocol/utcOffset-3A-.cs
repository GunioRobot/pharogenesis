utcOffset: anOffset

	"Answer a <DateAndTime> equivalent to the receiver but offset from UTC by anOffset"

	| equiv |
	equiv _ self + (anOffset asDuration - self offset).
	^ equiv ticks: (equiv ticks) offset: anOffset asDuration; yourself
