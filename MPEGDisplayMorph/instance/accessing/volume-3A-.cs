volume: aNumber 
	"Set the sound playback volume to the given level, between 0.0 and 1.0."

	volume := aNumber asFloat.
	volume := volume max: 0.0.
	volume := volume min: 1.0.
	soundTrack ifNotNil: [soundTrack volume: volume]