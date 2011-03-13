doesNotUnderstand: aMessage 
	 | ours |
"See it the message is a special setter that has not been defined.  Define it and try again."

	ours _ false.
	(aMessage selector endsWith: 'IncreaseBy:') ifTrue: [ours _ true].
	(aMessage selector endsWith: 'DecreaseBy:') ifTrue: [ours _ true].
	(aMessage selector endsWith: 'MultiplyBy:') ifTrue: [ours _ true].
	ours ifFalse: [^ super doesNotUnderstand: aMessage].
	(self addSpecialSetter: aMessage selector) ifFalse: ["not our inst var"
		^ super doesNotUnderstand: aMessage].
	^ aMessage sentTo: self