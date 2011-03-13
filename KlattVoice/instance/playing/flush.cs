flush
	"Play all the events in the queue, and then reset."
	| lastEventSegments |
	lastEvent isNil
		ifFalse: [lastEventSegments := self segments at: lastEvent phoneme ifAbsent: [self segments silence].
				self playEvent: lastEvent segments: lastEventSegments boundary: self segments end at: lastEventTime].
	super flush.
	self reset