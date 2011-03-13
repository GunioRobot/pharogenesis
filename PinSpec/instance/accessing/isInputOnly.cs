isInputOnly
	direction = #input ifTrue: [^ true].
	direction = #ioAsInput ifTrue: [^ true].
	^ false