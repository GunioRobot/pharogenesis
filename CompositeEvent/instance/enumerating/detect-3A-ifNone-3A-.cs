detect: aBlock ifNone: exceptionBlock
	self do: [ :each | (aBlock value: each) ifTrue: [^ each]].
	^ exceptionBlock value