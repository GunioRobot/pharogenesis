resumeFrom: scorePlayer

	| time |
	"New movie clip style of use."
	time _ scorePlayer ticksSinceStart.
	time < self startTime ifTrue: [^ self].  "It's not my time yet"
	time > self endTime ifTrue: [^ self].  "It's past my time"

	"The player is starting in the midst of this clip."
	movieClipPlayer openFileNamed: movieClipFileName
				withScorePlayer: soundTrackPlayerReady copy
				andPlayFrom: (self frameAtTick: time);
		setCueMorph: self.
