fromSeconds: seconds
	"Answer a DateAndTime since the Squeak epoch: 1 January 1901"

	| since |
	since _ Duration days: SqueakEpoch hours: 0 minutes: 0 seconds: seconds.
	^ self basicNew
		ticks: since ticks offset: self localOffset;
		yourself.
