mainLineStartingAt: aVersion
	"Answer all versions based on aVersion that are not branches (they have 
	the same number of digits with the same values, except the last value is
	greater than the last value of aVersion)."

	| answer tmp |
	answer := OrderedCollection new.
	tmp := aVersion.
	[versions includes: tmp] 
		whileTrue: 
			[answer add: tmp.
			tmp := tmp next].
	^answer
