keepIndexInView: index

	| newStart |
	index < startIndex ifTrue: [
		newStart _ index - (bounds width - (2 * borderWidth)) + 1.
		^ self startIndex: (newStart max: 1)].
	index > (startIndex + bounds width - (2 * borderWidth)) ifTrue: [
		^ self startIndex: (index min: data size)].
