readMonoChannelDataFrom: s
	"Read monophonic channel data from the given stream. Each frame contains a single sample."

	| buf w |
	buf _ channelData at: 1.  "the only buffer"
	bitsPerSample = 8
		ifTrue: [
			1 to: frameCount do: [:i |
				w _ s next.
				w > 127 ifTrue: [w _ w - 256].
				buf at: i put: (w bitShift: 8)]]
		ifFalse: [
			1 to: frameCount do: [:i |
				w _ (s next bitShift: 8) + s next.
				w > 32767 ifTrue: [w _ w - 65536].
				buf at: i put: w]].
