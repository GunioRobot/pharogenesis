cursor: aNumber

	| truncP |
	cursor ~= aNumber ifTrue:  [
		cursor _ aNumber.
		truncP _ aNumber truncated.
		truncP > data size ifTrue: [cursor _ data size].
		truncP < 0 ifTrue: [cursor _ 1].
		self keepIndexInView: truncP.
		self changed].
