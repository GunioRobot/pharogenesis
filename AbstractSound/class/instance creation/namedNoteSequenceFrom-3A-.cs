namedNoteSequenceFrom: anArray
	"Build a note sequence (i.e., a SequentialSound) from the given array. Elements are either (pitchName, duration, loudness) triples or (#rest duration) pairs."

	| score |
	score _ SequentialSound new.
	anArray do: [ :el |
		el size = 3 ifTrue: [
			score add: (self pitch: (self pitchForName: (el at: 1)) dur: (el at: 2) loudness: (el at: 3)).
		] ifFalse: [
			score add: (RestSound dur: (el at: 2)).
		].
	].
	^ score