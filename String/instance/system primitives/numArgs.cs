numArgs
	"Answer either the number of arguments that the receiver would take if considered a selector.  Answer -1 if it couldn't be a selector.  Note that currently this will answer -1 for anything begining with an uppercase letter even though the system will accept such symbols as selectors.  It is intended mostly for the assistance of spelling correction."

	| firstChar numColons |
	firstChar _ self at: 1.
	firstChar isLetter ifTrue:
		[ firstChar isUppercase ifTrue: [ ^ -1 ].
		numColons _ 0. 
		self do: [ :ch |
			ch tokenish ifFalse: [ ^ -1 ].
			(ch = $:) ifTrue: [numColons _ numColons + 1] ].
		^ (self last = $:)
			ifTrue: [ numColons > 0 ifTrue: [ numColons ] ifFalse: [ -1 ] ]
			ifFalse: [ numColons > 0 ifTrue: [ -1 ] ifFalse: [ 0 ] ] ].
	firstChar isSpecial ifTrue:
		[self size = 1 ifTrue: [^ 1].
		2 to: self size do: [:i | (self at: i) isSpecial ifFalse: [^ -1]].
		^ 1].
	^ -1.