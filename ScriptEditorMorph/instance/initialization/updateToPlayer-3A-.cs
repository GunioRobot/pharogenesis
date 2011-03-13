updateToPlayer: newPlayer
	"Make certain that the script name and the names of actors within are up to date"

	| currentName titleMorph |
	playerScripted ifNil: ["likely a naked test/yes/no fragment!" ^ self].

	newPlayer == playerScripted ifTrue: [^ self].  "Already points to him"
	self allMorphs do:
		[:m | (m isKindOf: TileMorph) ifTrue:
			[m retargetFrom: playerScripted to: newPlayer.
			m bringUpToDate]].
	playerScripted _ newPlayer.

	currentName _ playerScripted externalName.
	submorphs size = 0 ifTrue: [^ self].
	self firstSubmorph "align" submorphsDo: [:m | "try quick way"
				m knownName = 'title' ifTrue: [titleMorph _ m]].
	titleMorph ifNil:
		[titleMorph _ self firstSubmorph findDeepSubmorphThat: [:m | m knownName = 'title'] 
								ifAbsent: [nil]].
	titleMorph ifNotNil:
		[titleMorph label: currentName, ' ', self scriptName font: ScriptingSystem fontForTiles]