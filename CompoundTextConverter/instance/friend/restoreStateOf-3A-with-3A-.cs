restoreStateOf: aStream with: aConverterState

	state _ aConverterState copy.
	aStream position: state streamPosition.
