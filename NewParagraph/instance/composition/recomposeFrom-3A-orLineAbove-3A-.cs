recomposeFrom: characterIndex orLineAbove: lineAbove
	"lineAbove is true when there is need to recompose the prior line (not strictly the one above) as well, owing to edits that may have affected, eg, word breaks."
	| priorLines startLine |
	startLine _ self lineIndexForCharacter: characterIndex.
	lineAbove ifTrue: [startLine _ startLine-1 max: 1].
	[startLine > 1 and: [(lines at: startLine-1) top = (lines at: startLine) top]]
		whileTrue: [startLine _ startLine - 1].  "Find leftmost of line pieces"
	priorLines _ OrderedCollection new: lines size + 1.
	1 to: startLine-1 do: [:i | priorLines addLast: (lines at: i)].
	self composeLinesFrom: (lines at: startLine) first
		withLines: priorLines
		atY: (lines at: startLine) top