turnOffSoundWhile: aBlock
	"Turn off page flip sound during the given block."

	| old |
	old _ PageFlipSoundOn.
	PageFlipSoundOn _ false.
	aBlock value.
	PageFlipSoundOn _ old.
