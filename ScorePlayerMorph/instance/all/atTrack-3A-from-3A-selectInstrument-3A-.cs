atTrack: trackIndex from: aPopUpChoice selectInstrument: selection

	| oldSnd name snd |
	oldSnd _ scorePlayer instrumentForTrack: trackIndex.
	(selection beginsWith: 'edit ') ifTrue: [
		name _ selection copyFrom: 6 to: selection size.
		aPopUpChoice contentsClipped: name.
		(oldSnd isKindOf: FMSound) ifFalse: [^ self].
		EnvelopeEditorMorph openOn: oldSnd title: name.
		^ self].

	snd _ nil.
	1 to: instrumentSelector size do: [:i |
		((trackIndex ~= i) and:
		 [selection = (instrumentSelector at: i) contents])
			ifTrue: [snd _ scorePlayer instrumentForTrack: i]].  "use existing instrument prototype"

	snd ifNil: [
		selection = 'clink'
			ifTrue: [
				snd _ (SampledSound
					samples: SampledSound coffeeCupClink
					samplingRate: 11025) copy]
			ifFalse: [snd _ (AbstractSound soundNamed: selection) copy]].

	scorePlayer instrumentForTrack: trackIndex put: snd.
	(instrumentSelector at: trackIndex) contentsClipped: selection.
