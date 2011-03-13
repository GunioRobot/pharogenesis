trace: aBlock		"ContextPart trace: [3 factorial]"
	"This method uses the simulator to print calls and returned values in the Transcript."
	| prev current |
	Transcript clear.
	prev _ aBlock.
	^ thisContext sender
		runSimulated: aBlock
		contextAtEachStep:
			[:current |
			Sensor anyButtonPressed ifTrue: [^ nil].
			current == prev
				ifFalse:
					[prev sender == nil ifTrue:  "returning"
						[Transcript space; nextPut: $^; print: current top].
					Transcript cr;
						nextPutAll: (String new: (current depthBelow: aBlock) withAll: $ );
						print: current receiver; space; nextPutAll: current selector; endEntry.
					prev _ current]]