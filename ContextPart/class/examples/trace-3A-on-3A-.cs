trace: aBlock on: aStream		"ContextPart trace: [3 factorial]"
	"This method uses the simulator to print calls to a file."
	| prev |
	prev _ aBlock.
	^ thisContext sender
		runSimulated: aBlock
		contextAtEachStep:
			[:current |
			Sensor anyButtonPressed ifTrue: [^ nil].
			current == prev
				ifFalse:
					[prev sender ifNil:
						[aStream space; nextPut: $^.
						self carefullyPrint: current top on: aStream].
					aStream cr.
					(current depthBelow: aBlock) timesRepeat: [aStream space].
					self carefullyPrint: current receiver on: aStream.
					aStream space; nextPutAll: current selector; flush.
					prev _ current]]