stopStepping: aMorph
	"Remove the given morph from the step list."

	self stepList copy do: [:entry |
		entry first == aMorph ifTrue: [self stepList remove: entry ifAbsent: []]].
