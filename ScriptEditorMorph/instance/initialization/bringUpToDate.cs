bringUpToDate
	"Make certain that the script name and the names of actors within are up to date"

	| currentName titleMorph newName |
	playerScripted ifNil: ["likely a naked test/yes/no fragment!" ^ self].

	currentName _ playerScripted externalName.
	titleMorph _ self findDeepSubmorphThat: [:m | m externalName = 'title'] ifAbsent: [nil].
	titleMorph ifNotNil:
		[newName _ self isAnonymous
			ifTrue:
				['script']
			ifFalse:
				[self scriptName].
		titleMorph label: currentName, ' ', newName font: ScriptingSystem fontForTiles]