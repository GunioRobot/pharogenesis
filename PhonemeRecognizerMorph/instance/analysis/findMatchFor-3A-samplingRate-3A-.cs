findMatchFor: aSoundBuffer samplingRate: samplingRate
	"Find the phoneme whose features most closesly match those of the given sound buffer."

	| unknown bestMatch bestDistance d |
	unknown _ PhonemeRecord new
		samples: aSoundBuffer samplingRate: samplingRate.
	unknown peakLevel > 1500
		ifTrue: [
			unknown computeFeatures.
			bestMatch _ nil.
			bestDistance _ SmallInteger maxVal.
			phonemeRecords do: [:p |
				d _ p featureDistanceFrom: unknown features to: p features.
				d < bestDistance ifTrue: [
					bestMatch _ p.
					bestDistance _ d]]]
		ifFalse: [bestMatch _ silentPhoneme].
	currentPhoneme _ bestMatch.
	^ currentPhoneme
