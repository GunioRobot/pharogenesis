allDefaultValueSubtableAt: index

	| t |
	t _ self basicAt: index.
	t ifNil: [^ true].
	t do: [:e |
		e ~= defaultValue ifTrue: [^ false].
	].
	^ true.
