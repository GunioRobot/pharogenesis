coverter: aTextConverter

	converter class ~= aTextConverter class ifTrue: [
		converter _ aTextConverter.
		vmPathName _ squeakPathName convertToWithConverter: converter
	].
