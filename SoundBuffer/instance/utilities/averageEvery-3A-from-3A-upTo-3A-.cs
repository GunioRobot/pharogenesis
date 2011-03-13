averageEvery: nSamples from: anotherBuffer upTo: inCount

	| fromIndex sum |

	fromIndex _ 1.
	1 to: inCount // nSamples do: [ :i |
		sum _ 0.
		nSamples timesRepeat: [
			sum _ sum + (anotherBuffer at: fromIndex).
			fromIndex _ fromIndex + 1.
		].
		self at: i put: sum // nSamples.
	].
