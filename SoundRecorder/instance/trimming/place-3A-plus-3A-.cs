place: startPlace plus: nSamples
	"Return the place that is nSamples (may be negative) beyond thisPlace."

	| i j remaining buf |
	i _ startPlace first.
	j _ startPlace second.
	nSamples >= 0
	ifTrue: [remaining _ nSamples.
			[buf _ recordedBuffers at: i.
			(j + remaining) <= buf size ifTrue: [^ Array with: i with: j + remaining].
			i < recordedBuffers size]
				whileTrue: [remaining _ remaining - (buf size - j + 1).
							i _ i+1.  j _ 1].
			^ self endPlace]
	ifFalse: [remaining _ nSamples negated.
			[buf _ recordedBuffers at: i.
			(j - remaining) >= 1 ifTrue: [^ Array with: i with: j - remaining].
			i > 1]
				whileTrue: [remaining _ remaining - j.
							i _ i-1.  j _ (recordedBuffers at: i) size].
			^ #(1 1)]