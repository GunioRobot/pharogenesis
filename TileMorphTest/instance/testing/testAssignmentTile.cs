testAssignmentTile
	"self debug: #testAssignmentTile"

	| player viewer tile phrase |
	player _ Morph new assuredPlayer.
	viewer _ CategoryViewer new invisiblySetPlayer: player.
	viewer  makeSetter: #(#getX #Number) event: nil from: player costume.
	phrase _ ActiveHand firstSubmorph.
	ActiveHand removeAllMorphs.
	tile _ phrase submorphs second.

	self assert: tile codeString = 'setX: '.
	tile arrowAction: 1.
	self assert: tile codeString = 'setX: self getX + '.

