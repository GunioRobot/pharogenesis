bringUpToDate
	"Make certain that the script name and the names of players within are up to date"

	| currentName titleMorph |
	playerScripted ifNil: ["likely a naked test/yes/no fragment!" ^ self].

	currentName _ playerScripted externalName.
	submorphs size = 0 ifTrue: [^ self].
	self firstSubmorph "align" submorphsDo: [:m | "try quick way"
				m knownName = 'title' ifTrue: [titleMorph _ m]].
	titleMorph ifNil: [
		titleMorph _ self firstSubmorph findDeepSubmorphThat: [:m | m knownName = 'title'] 
								ifAbsent: [nil]].
	titleMorph ifNotNil:
		[titleMorph label: currentName, ' ', self scriptName font: ScriptingSystem fontForTiles]