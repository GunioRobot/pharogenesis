insertionIndexFor: aMorph
	"Find the right place to put the given dropped morph."

	| p rowBase i morphsForThisRow |
	p _ aMorph center.
	rowBase _ bounds top + borderWidth.
	i _ 1.
	[i <= submorphs size] whileTrue: [
		morphsForThisRow _ self rowMorphsStartingAt: i.
		rowBase _ self rowBaseFor: morphsForThisRow lastRowBase: rowBase.
		rowBase > p y ifTrue: [  "found row"
			morphsForThisRow do: [:m |
				m center x > p x ifTrue: [^ i].  "found index in row"
				i _ i + 1].
			^ i].
		i _ i + morphsForThisRow size].
	^ submorphs size + 1  "insert at end"
