fromSeconds: seconds
	"Answer a DateAndTime since the Squeak epoch: 1 January 1901"

	^ self basicNew ticks: (Array with: SqueakEpoch with: seconds with: 0) offset: self localOffset
