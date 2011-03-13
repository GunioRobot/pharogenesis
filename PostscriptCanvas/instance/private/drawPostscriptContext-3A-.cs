drawPostscriptContext: subCanvas
	| contents |
	(contents _ subCanvas contents) ifNil: [^ self].
	^ target comment: ' sub-canvas start';
		preserveStateDuring: [:inner | inner print: contents];
		comment: ' sub-canvas stop'.	

