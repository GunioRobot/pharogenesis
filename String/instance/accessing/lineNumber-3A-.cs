lineNumber: anIndex
	"Answer a string containing the characters in the given line number.  5/10/96 sw"

	| crString pos finalPos |
	crString _ String with: Character cr.
	pos _ 0.
	1 to: anIndex - 1 do:
		[:i | pos _ self findString: crString startingAt: pos + 1.
			pos == 0 ifTrue: [^ nil]].
	finalPos _ self findString: crString startingAt: pos + 1.
	finalPos == 0 ifTrue: [finalPos _ self size + 1].
	^ self copyFrom: pos + 1 to: finalPos - 1

"
'Fred
the
Bear' lineNumber: 3
"