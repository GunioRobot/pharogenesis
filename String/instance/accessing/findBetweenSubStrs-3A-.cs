findBetweenSubStrs: delimiters
	"Answer the collection of tokens that result from parsing self.  Tokens are separated by substrings, as listed in the Array delimiters."

	| tokens keyStart keyStop |
	tokens _ OrderedCollection new.
	keyStop _ 1.
	[keyStop <= self size] whileTrue:
		[keyStart _ self skipAnySubStr: delimiters startingAt: keyStop.
		keyStop _ self findAnySubStr: delimiters startingAt: keyStart.
		keyStart < keyStop
			ifTrue: [tokens add: (self copyFrom: keyStart to: (keyStop - 1))]].
	^tokens