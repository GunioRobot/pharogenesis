delete
	(owner isKindOf: PianoRollScoreMorph) ifTrue:
		[owner score removeAmbientEventWithMorph: self.
		endMorph ifNotNil: [owner score removeAmbientEventWithMorph: endMorph]].
	endMorph ifNotNil: [endMorph delete].
	soundTrackMorph ifNotNil: [soundTrackMorph delete].
	colorMorph ifNotNil: [colorMorph delete].
	super delete.
