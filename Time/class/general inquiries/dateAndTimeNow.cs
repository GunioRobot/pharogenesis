dateAndTimeNow
	"Answer a two-element Array of (Date today, Time now)."

	| secondCount d t |
	secondCount _ self primSecondsClock.
	d _ Date fromSeconds: secondCount.
	t _ Time fromSeconds: secondCount \\ 86400.
	^ Array with: d with: t