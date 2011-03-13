tracks: trackList

	tracks _ trackList asArray collect: [:trackEvents | trackEvents asArray].
	self ambientTrack.  "Assure it's not nil"