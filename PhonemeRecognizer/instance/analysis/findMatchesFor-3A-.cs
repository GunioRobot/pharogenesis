findMatchesFor: aSampledSound
	"Process a sampled sound and return a sequence of phoneme matches for that sound."

	| out fftSize samplesPerInterval startIndex buf p |

	out := OrderedCollection new: 1000.
	fftSize := PhonemeRecord fftSize.
	samplesPerInterval := aSampledSound samplingRate / 24.0.
	1 to: (aSampledSound samples size - fftSize) + 1 by: samplesPerInterval do: [:i |
		startIndex := i truncated.
		buf := aSampledSound samples copyFrom: startIndex to: startIndex + fftSize - 1.
		p :=	self findMatchFor: buf samplingRate: aSampledSound samplingRate.
		out addLast: p.
	].
	^ out asArray.