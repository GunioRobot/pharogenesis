splitIntoTracks
	"Split a type zero MIDI file into separate tracks by channel number."

	| newTempoMap newTracks |
	tracks size = 1 ifFalse: [self error: 'expected exactly one track in type 0 file'].
	tempoMap ifNotNil: [self error: 'did not expect a tempo map in type 0 file'].
	newTempoMap _ OrderedCollection new.
	newTracks _ (1 to: 16) collect: [:i | OrderedCollection new].
	tracks first do: [:e |
		e isTempoEvent
			ifTrue: [newTempoMap addLast: e]
			ifFalse: [(newTracks at: e channel + 1) addLast: e]].
	newTempoMap size > 0 ifTrue: [tempoMap _ newTempoMap asArray].
	newTracks _ newTracks select: [:t | self trackContainsNotes: t].
	tracks _ newTracks collect: [:t | t asArray].
	trackInfo _ trackInfo, ((2 to: tracks size) collect: [:i | '']).
