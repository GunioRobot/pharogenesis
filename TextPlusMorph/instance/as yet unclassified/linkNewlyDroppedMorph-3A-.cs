linkNewlyDroppedMorph: aMorph

	| ed para lineToUse |

	ed _ self editor.
	para _ self paragraph.
	lineToUse _ para lines detect: [ :each | each bottom > aMorph top] ifNone: [para lines last].
	ed selectFrom: lineToUse first to: lineToUse last.
	self addAlansAnchorFor: aMorph.

