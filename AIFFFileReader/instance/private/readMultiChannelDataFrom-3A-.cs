readMultiChannelDataFrom: s
	"Read multi-channel data from the given stream. Each frame contains channelCount samples."

	| w |
	bitsPerSample = 8
		ifTrue: [
			1 to: frameCount do: [:i |
				1 to: channelCount do: [:ch |
					w _ s next.
					w > 127 ifTrue: [w _ w - 256].
					(channelData at: ch) at: i put: (w bitShift: 8)]]]
		ifFalse: [
			1 to: frameCount do: [:i |
				1 to: channelCount do: [:ch |
					w _ (s next bitShift: 8) + s next.
					w > 32767 ifTrue: [w _ w - 65536].
					(channelData at: ch) at: i put: w]]].
