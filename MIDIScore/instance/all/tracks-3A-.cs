tracks: trackList

	tracks _ trackList asArray collect: [:trackEvents | trackEvents asArray].
