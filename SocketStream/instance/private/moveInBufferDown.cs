moveInBufferDown
	"Move down contents of inBuffer to the start.
	Return distance moved."

	| sz distanceMoved |
	sz _ inNextToWrite - lastRead - 1.
	inBuffer replaceFrom: 1 to: sz with: inBuffer startingAt: lastRead + 1.
	distanceMoved _ lastRead.
	lastRead _ 0.
	inNextToWrite _ sz + 1.
	^distanceMoved
