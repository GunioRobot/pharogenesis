scanForEndThreshold: threshold dcOffset: dcOffset
	"Return an array containing the (<buffer index>, <sample index in buffer>) of the last sample whose absolute value is over the given threshold after subtracting the given DC offset."

	| extraSamples buf s |
	extraSamples _ 1000.  "number of samples after triggering sample to include"
	recordedBuffers size to: 1 by: -1 do: [:i |
		buf _ recordedBuffers at: i.
		buf size to: 1 by: -1 do: [:j |
			s _ (buf at: j) - dcOffset.
			s < 0 ifTrue: [s _ s negated].
			s > threshold ifTrue: [  "found end"
				(j + extraSamples) <= buf size
					ifTrue: [^ Array with: i with: j + extraSamples]
					ifFalse: [
						i < recordedBuffers size
							ifTrue: [^ Array with: i + 1 with: extraSamples - (buf size - j)]
							ifFalse: [^ Array with: i with: buf size]]]]].

	^ Array with: recordedBuffers size with: recordedBuffers last size
