step

	running ifTrue: [
		self oneStep.
		self changed].
