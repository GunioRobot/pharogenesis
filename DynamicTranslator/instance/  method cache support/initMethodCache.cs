initMethodCache

	1 to: MethodCacheSize do: [ :i | methodCache at: i put: 0 ].
	mcProbe _ 0.