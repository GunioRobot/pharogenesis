keepIndexInView: index

	| w newStart |
	w _ bounds width - (2 * borderWidth).
	index < startIndex ifTrue: [
		newStart _ index - w + 1.
		^ self startIndex: (newStart max: 1)].
	index > (startIndex + w) ifTrue: [
		^ self startIndex: (index min: data size)].
