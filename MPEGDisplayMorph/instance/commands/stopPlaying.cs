stopPlaying
	"Stop playing the movie."

	running _ false.
	soundTrack ifNotNil: [soundTrack pause].
