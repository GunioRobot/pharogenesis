stopPlaying
	"Stop playing the movie."

	running := false.
	soundTrack ifNotNil: [soundTrack pause].
