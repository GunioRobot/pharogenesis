primFooIntegerSumAnd: x with: y

	<primitive: 'primFooIntegerSumAnd' module: 'FooPlugin2'>
	^"FooPlugin2 
		doPrimitive: 'primFooIntegerSumAnd:with:'
		withArguments: {x . y}" 'Whoops!'