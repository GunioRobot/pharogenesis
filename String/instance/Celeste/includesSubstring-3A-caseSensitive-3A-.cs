includesSubstring: aString caseSensitive: caseSensitive
	"Note: Although less general than the 'match:' method, this method was a factor of 10 faster on both successful and unsucessful finds of a short string in a 1116 byte mail message."
	
	| first index i |
	self isEmpty ifTrue: [^false].
	caseSensitive ifTrue: [
		first _ aString first.
		1 to: self size - aString size + 1 do: [ :start |
			(self at: start) = first ifTrue: [
				i _ 1.
				[(self at: start + i - 1) = (aString at: i)] whileTrue: [
					i = aString size ifTrue: [^true].
					i _ i + 1.
				].
			].
		].
	] ifFalse: [
		first _ aString first asLowercase.
		1 to: self size - aString size + 1 do: [ :start |
			(self at: start) asLowercase = first ifTrue: [
				i _ 1.
				[(self at: start + i - 1) asLowercase =
				 (aString at: i) asLowercase] whileTrue: [
					i = aString size ifTrue: [^ true].
					i _ i + 1.
				].
			].
		].
	].
	^ false