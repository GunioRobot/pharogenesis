lineIndexForCharacter: index
	"Answer the index of the line in which to select the character at index."
	lines size <= 1 ifTrue: [^ 1].
	2 to: lines size do: 
		[:i | (lines at: i) first > index ifTrue: [^ i-1]].
	^ lines size