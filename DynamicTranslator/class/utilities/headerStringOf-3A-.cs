headerStringOf: tMeth
	^String streamContents: [:str | str
		print: (tMeth at: MethodClassIndex + 1);
		nextPutAll: '>>';
		print: (tMeth at: MethodSelectorIndex + 1);
		nextPutAll: ' (args='; print: (tMeth at: MethodArgCountIndex + 1);
		nextPutAll: ', prim='; print: (tMeth at: MethodPrimIndex + 1);
		nextPutAll: ', bias='; print: (tMeth at: MethodBiasIndex + 1);
		nextPutAll: ', cycle='; print: (tMeth at: MethodCycleIndex + 1);
		nextPut: $)]