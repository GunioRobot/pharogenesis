dragoverString

	^ popOutOnDragOver
		ifTrue:
			['cease popping out on dragover']
		ifFalse:
			['start popping out on dragover']