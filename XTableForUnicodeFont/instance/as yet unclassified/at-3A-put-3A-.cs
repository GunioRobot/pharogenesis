at: index put: value

	ranges with: xTables do: [:range :xTable |
		(range first <= index and: [index <= range last]) ifTrue: [
			^ xTable at: index - range first + 1 put: value.
		].
	].
	^ 0.
