stats
	| oop fieldAddr fieldOop last stats v d |
	stats _ Bag new.
	oop _ self firstObject.

'Scanning the image...' displayProgressAt: Sensor cursorPoint
	from: oop to: endOfMemory
	during: [:bar |

	[oop < endOfMemory] whileTrue:
		[(self isFreeObject: oop) ifFalse:
			[stats add: #objects.
			fieldAddr _ oop + (self lastPointerOf: oop).
			[fieldAddr > oop] whileTrue:
				[fieldOop _ self longAt: fieldAddr.
				(self isIntegerObject: fieldOop)
					ifTrue: [v _ self integerValueOf: fieldOop.
							(v between: -16000 and: 16000)
								ifTrue: [stats add: #ints32k]
								ifFalse: [stats add: #intsOther]]
					ifFalse: [fieldOop = nilObj ifTrue: [stats add: #nil]
							ifFalse:
							[d _ fieldOop - oop.
							(d between: -16000 and: 16000)
								ifTrue: [stats add: #oops32k]
								ifFalse: [stats add: #oopsOther]]].
				fieldAddr _ fieldAddr - 4]].
		bar value: oop.
		last _ oop.
		last _ last.
		oop _ self objectAfter: oop]].
	^ stats sortedElements