otherPlayersDo: playerBlock
	"Not elegant -- scan for any players registered in the ambientTrack,
	and evaluate the block for them."
	| players p |
	ambientTrack == nil ifTrue: [^ self].
	players _ Set new.
	ambientTrack do:
		[:evt | p _ evt relatedPlayer.
		p ifNotNil: [players add: p]].
	players do: playerBlock