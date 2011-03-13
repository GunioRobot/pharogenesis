playPhoneticEvent: event at: time
	| lastEventSegments boundarySegment |
	"Play an event."
	lastEvent isNil
		ifFalse: [lastEventSegments := self segments at: lastEvent phoneme ifAbsent: [self segments silence].
				boundarySegment := (self segments at: event phoneme ifAbsent: [self segments silence]) first.
				self playEvent: lastEvent segments: lastEventSegments boundary: boundarySegment at: lastEventTime].
	lastEvent := event.
	lastEventTime := time