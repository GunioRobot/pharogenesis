add: aMessage 
	current isNil ifTrue: [current _ OrderedCollection new].
	current add: aMessage.
	(current size > 20) 
		ifTrue: [current _ current copyFrom: (current size - 20) to: (current size)]