testSoundTile
	"self debug: #testSoundTile"
	| tile dummy |
	dummy _ Morph new.
	tile _ SoundTile new literal: 'croak'.
	dummy addMorph: tile.
	tile arrowAction: 1.
	self assert: tile codeString = '(''silence'')'.

	