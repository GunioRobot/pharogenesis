extractSchemeFrom: aString
	| colonIndex slashIndex |
	colonIndex _ aString indexOf: $: .
	^colonIndex > 0
		ifTrue: [
			slashIndex _ aString indexOf: $/ .
			(slashIndex == 0
				or: [colonIndex < slashIndex])
				ifTrue: [aString copyFrom: 1 to: colonIndex-1]
				ifFalse: [nil]]
		ifFalse: [nil]