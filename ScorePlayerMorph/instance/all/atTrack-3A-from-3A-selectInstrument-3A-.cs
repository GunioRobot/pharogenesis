atTrack: trackIndex from: aPopUpChoice selectInstrument: instName
	| snd |
	(instName beginsWith: 'edit ') ifTrue:
		[aPopUpChoice contentsClipped: (trackInstNames at: trackIndex).
		snd _ scorePlayer instrumentForTrack: trackIndex.
		(snd isKindOf: FMSound) ifFalse: [^ self].
		EnvelopeEditorMorph openOn: snd title: (trackInstNames at: trackIndex).
		^ self].
	instName = 'clink'
		ifTrue: [
			snd _ SampledSound
				samples: SampledSound coffeeCupClink
				samplingRate: 11025]
		ifFalse: [snd _ AbstractSound soundNamed: instName].

	scorePlayer instrumentForTrack: trackIndex put: snd copy.
	trackInstNames at: trackIndex put: instName

