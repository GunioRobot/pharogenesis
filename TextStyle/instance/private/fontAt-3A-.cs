fontAt: index 
	"This is private because no object outside TextStyle should depend on the 
	representation of the font family in fontArray."

	((fontArray atPin: index) isMemberOf: StrikeFont)
				ifTrue: [^fontArray atPin: index].
	((fontArray at: 1) isMemberOf: StrikeFont)
				ifTrue: [^fontArray at: 1].
	self error: 'No valid fonts in font array'