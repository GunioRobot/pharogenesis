validate
	| oop prev |
	Transcript show: 'Validating...'.
	oop _ self firstObject.
	[oop < endOfMemory] whileTrue: [
		self validate: oop.
		prev _ oop.  "look here if debugging prev obj overlapping this one"
		oop _ self objectAfter: oop.
	].
	Transcript show: 'done.'; cr