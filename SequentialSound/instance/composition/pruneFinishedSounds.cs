pruneFinishedSounds
	"Remove any sounds that have been completely played."

	| newSnds |
	(currentIndex > 1 and: [currentIndex < sounds size]) ifFalse: [^ self].
	newSnds _ sounds copyFrom: currentIndex to: sounds size.
	currentIndex _ 1.
	sounds _ newSnds.
