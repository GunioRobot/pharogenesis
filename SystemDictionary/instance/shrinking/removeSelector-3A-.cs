removeSelector: descriptor
	"Safely remove a selector from a class (or metaclass). If the class
	or the method doesn't exist anymore, never mind and answer nil.
	This method should be used instead of 'Class removeSelector: #method'
	to omit global class references."

	| class sel |
	class _ Smalltalk at: descriptor first ifAbsent: [^ nil].
	(descriptor size > 2 and: [descriptor second == #class])
		ifTrue:
			[class _ class class.
			sel _ descriptor third]
		ifFalse: [sel _ descriptor second].
	^ class removeSelector: sel