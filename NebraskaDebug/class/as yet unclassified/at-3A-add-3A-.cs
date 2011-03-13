at: queueName add: anArray

	| now |

	DEBUG ifNil: [
		queueName == #sketchZZZ ifFalse: [^self].
		"Details _ OrderedCollection new."
		self beginStats.
	].
	(Details notNil and: [Details size < 20]) ifTrue: [
		Details add: thisContext longStack
	].
	now _ Time millisecondClockValue.
	DEBUG add: {now},anArray,{queueName}.
