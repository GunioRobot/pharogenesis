durationInTicks
	
	| t |
	t _ 0.
	tracks, {self ambientTrack} do:
		[:track |
		track do:
			[:n | (n isNoteEvent)
				ifTrue: [t _ t max: n endTime]
				ifFalse: [t _ t max: n time]]].
	^ t
