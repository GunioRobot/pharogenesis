atChannel: channelIndex from: aPopUpChoice selectInstrument: selection

	| oldSnd name snd instSelector |
	oldSnd _ midiSynth instrumentForChannel: channelIndex.
	(selection beginsWith: 'edit ') ifTrue: [
		name _ selection copyFrom: 6 to: selection size.
		aPopUpChoice contentsClipped: name.
		(oldSnd isKindOf: FMSound) | (oldSnd isKindOf: LoopedSampledSound) ifTrue: [
			EnvelopeEditorMorph openOn: oldSnd title: name].
		(oldSnd isKindOf: SampledInstrument) ifTrue: [
			EnvelopeEditorMorph openOn: oldSnd allNotes first title: name].
		^ self].

	snd _ nil.
	1 to: instrumentSelector size do: [:i |
		((channelIndex ~= i) and:
		 [(instSelector _ instrumentSelector at: i) notNil and:
		 [selection = instSelector contents]])
			ifTrue: [snd _ midiSynth instrumentForChannel: i]].  "use existing instrument prototype"

	snd ifNil: [
		selection = 'clink'
			ifTrue: [
				snd _ (SampledSound
					samples: SampledSound coffeeCupClink
					samplingRate: 11025) copy]
			ifFalse: [snd _ (AbstractSound soundNamed: selection) copy]].

	midiSynth instrumentForChannel: channelIndex put: snd.
	(instrumentSelector at: channelIndex) contentsClipped: selection.
