soundForTrack: trackIndex after: eventIndex ticks: ticks instrument: soundProto secsPerTick: secsPerTick

	| track evt |
	track _ tracks at: trackIndex.
	eventIndex > track size ifTrue: [^ nil].
	evt _ track at: eventIndex.
	evt time <= ticks ifTrue: [
		evt isNoteEvent ifFalse: [^ RestSound dur: 0.001].  "skip non-note event"
		^ (soundProto copy
			setPitch: evt pitch
			dur: secsPerTick * evt duration
			loudness: evt velocity asFloat / 127.0)].
	^ nil
