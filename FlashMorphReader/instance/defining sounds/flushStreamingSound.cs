flushStreamingSound

	| bufs sound |
	streamingSound buffers ifNil: [^ self].
	streamingSound buffers first position = 0 ifFalse: [
		bufs := streamingSound buffers collect: [:b | b contents].
		sound := self createSoundFrom: bufs
					stereo: streamingSound stereo
					samplingRate: streamingSound samplingRate.
		player addSound: sound at: streamingSound firstFrame].
	streamingSound firstFrame: frame.
	streamingSound frameNumber: frame.
	streamingSound buffers do: [:s | s reset].
