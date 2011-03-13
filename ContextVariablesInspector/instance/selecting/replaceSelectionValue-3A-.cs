replaceSelectionValue: anObject 
	"Refer to the comment in Inspector|replaceSelectionValue:."

	| numTemps |
	selectionIndex <= 2 ifTrue: [^ self].
	numTemps _ object method numTemps.
	selectionIndex - 2 <= object method numTemps ifTrue: [
		^ object tempAt: selectionIndex - 2 put: anObject].
	^ object myEnv at: selectionIndex - 2 - numTemps put: anObject