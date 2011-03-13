startListening

	self stopListening.
	GlobalListener _ EToyPeerToPeer new awaitDataFor: self.
	self bumpUpdateCounter.

