resetPotentialDropRow
	potentialDropRow ifNotNil: [
	potentialDropRow ~= 0 ifTrue: [
		potentialDropRow _ 0.
		self changed. ] ]