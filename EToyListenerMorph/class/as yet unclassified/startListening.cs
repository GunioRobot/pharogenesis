startListening

	self stopListening.
	GlobalListener := EToyPeerToPeer new awaitDataFor: self.
	self bumpUpdateCounter.

