unparenthetically
	"If the receiver starts with (..( and ends with matching )..), strip them"

	| curr |
	curr _ self.
	[((curr first = $() and: [curr last = $)])] whileTrue:
		[curr _ curr copyFrom: 2 to: (curr size - 1)].

	^ curr

"

'((fred the bear))' unparenthetically

"
		