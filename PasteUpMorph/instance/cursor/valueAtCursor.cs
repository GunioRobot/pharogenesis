valueAtCursor
	"Answer the submorph of mine indexed by the value of my 'cursor' slot"

	submorphs isEmpty ifTrue: [^ self presenter standardPlayer costume].
	^ (submorphs at: ((cursor truncated max: 1) min: submorphs size)) morphRepresented