selection 
	"Refer to the comment in Inspector|selection."

	| numTemps |
	selectionIndex = 0 ifTrue:[^''].
	selectionIndex = 1 ifTrue: [^object].
	selectionIndex = 2 ifTrue: [^ object tempsAndValues].
	numTemps _ object method numTemps.
	selectionIndex - 2 <= object method numTemps ifTrue: [
		^ object tempAt: selectionIndex - 2].
	^ object myEnv at: selectionIndex - 2 - numTemps