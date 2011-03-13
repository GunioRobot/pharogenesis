mouseMove: evt

	| x w |
	x _ evt cursorPoint x - (bounds left + borderWidth).
	w _ self width - (2 * borderWidth).

	self changed.
	x < 0 ifTrue: [
		cursor _ startIndex + (3 * x).
		cursor _ (cursor max: 1) min: data size.
		^ self startIndex: cursor].
	x > w ifTrue: [
		cursor _ startIndex + w + (3 * (x - w)).
		cursor _ (cursor max: 1) min: data size.
		^ self startIndex: cursor - w].

	cursor _ ((startIndex + x) max: 1) min: data size.
