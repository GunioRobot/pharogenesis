trace: aBlock onFileNamed: fileName		"ContextPart trace: [3 factorial]"
	"This method uses the simulator to print calls to a file."
	| prev current f sel |
	f _ FileStream fileNamed: fileName.
	prev _ aBlock.
	thisContext sender
		runSimulated: aBlock
		contextAtEachStep:
			[:current |
			Sensor anyButtonPressed ifTrue: [^ nil].
			current == prev
				ifFalse:
					[f cr;
						nextPutAll: (String new: (current depthBelow: aBlock) withAll: $ );
						print: current receiver class; space; nextPutAll: (sel _ current selector); flush.
					prev _ current.
					sel == #error: ifTrue: [self halt]]].
	f close