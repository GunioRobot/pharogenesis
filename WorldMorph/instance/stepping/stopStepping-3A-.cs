stopStepping: aMorph
	"Remove the given morph from the step list."

	stepList copy do: [:entry |
		entry first == aMorph ifTrue: [stepList remove: entry ifAbsent: []]].
