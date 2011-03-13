newFrom: aCompiledMethod
	| inst |
	inst _ super basicNew: aCompiledMethod size.
	1 to: aCompiledMethod size do: [:index |
		inst at: index put: (aCompiledMethod at: index)].
	^ inst.