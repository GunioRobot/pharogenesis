initialize

	envelopes _ #().
	mSecsSinceStart _ 0.
	samplesUntilNextControl _ 0.
	scaledVol _ (1.0 * ScaleFactor) rounded.
	scaledVolIncr _ 0.
	scaledVolLimit _ scaledVol.
