scanForStartThreshold: threshold dcOffset: dcOffset
	"Return an array containing the (<buffer index>, <sample index in buffer>) of the first sample whose absolute value is over the given threshold after subtracting the given DC offset."

	| extraSamples buf s |
	extraSamples _ 350.  "number of samples before triggering sample to include"
	1 to: recordedBuffers size do: [:i |
		buf _ recordedBuffers at: i.
		1 to: buf size do: [:j |
			s _ (buf at: j) - dcOffset.
			s < 0 ifTrue: [s _ s negated].
			s > threshold ifTrue: [
				"found start"
				j > extraSamples
					ifTrue: [^ Array with: i with: j - extraSamples]
					ifFalse: [
						i > 1
							ifTrue: [^ Array with: i - 1 with: (recordedBuffers at: i - 1) size - (extraSamples - j)]
							ifFalse: [^ Array with: i with: 1]]]]].

	^ Array with: recordedBuffers size with: recordedBuffers last size
