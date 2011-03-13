findMatchFor: aSoundBuffer samplingRate: samplingRate
	"Find the phoneme whose features most closesly match those of the given sound buffer."

	| unknown bestMatch bestDistance d |
	unknown := PhonemeRecord new
		samples: aSoundBuffer samplingRate: samplingRate.
	unknown peakLevel > 1500
		ifTrue: [
			unknown computeFeatures.
			bestMatch := silentPhoneme.
			bestDistance := SmallInteger maxVal.
			phonemeRecords do: [:p |
				d := p featureDistanceFrom: unknown features to: p features.
				d < bestDistance ifTrue: [
					bestMatch := p.
					bestDistance := d]]]
		ifFalse: [bestMatch := silentPhoneme].
	^ bestMatch