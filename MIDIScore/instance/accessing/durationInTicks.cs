durationInTicks
	
	| t |
	t _ 0.
	tracks do:
		[:track |
		track do:
			[:n | (n isNoteEvent) ifTrue: [t _ t max: n endTime]]].
	^ t
