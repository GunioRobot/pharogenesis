objectBefore: addr
	| oop prev |
	oop _ self firstObject.
	[oop < endOfMemory] whileTrue: [
		prev _ oop.  "look here if debugging prev obj overlapping this one"
		oop _ self objectAfter: oop.
		oop >= addr ifTrue: [^ prev]
	]