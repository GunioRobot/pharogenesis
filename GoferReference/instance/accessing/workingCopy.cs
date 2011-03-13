workingCopy
	"Answer a working copy, or nil if the package is not loaded."

	^ MCWorkingCopy allManagers
		detect: [ :each | self matchesWorkingCopy: each ]
		ifNone: [ nil ]