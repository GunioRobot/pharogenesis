tilesFrom: msgNode in: aScriptor
	"Construct a single line of tiles from a MessageNode of a parse tree.  For a single message send."

	| tile pm sel instVar suff argNode selType |
	sel _ msgNode selector key.
	(sel beginsWith: 'assign') ifTrue: [	"assignment"
		instVar _ msgNode arguments first literalValue.
		instVar _ (instVar copyFrom: 4 to: instVar size) withFirstCharacterDownshifted.
		pm _ (CategoryViewer new) scriptedPlayer: aScriptor playerScripted; 
			makeSetter: nil from: aScriptor playerScripted costume 
			forPart: (Array with: instVar with: #number).	"makes a new Phrase"
		suff _ (sel findTokens: ':') first.
		suff _ (suff copyFrom: 7 to: suff size-6), ':'.		": Incr: Decr: Mult:"
		pm submorphs second setAssignmentSuffix: suff.
		pm submorphs third delete.
		tile _ TilePadMorph new tilesFrom: msgNode arguments last in: aScriptor.
		pm addMorphBack: tile.
		^ pm].

	(sel beginsWith: 'get') ifTrue: [	"getter"
		instVar _ (sel copyFrom: 4 to: sel size) withFirstCharacterDownshifted.
		pm _ (CategoryViewer new) scriptedPlayer: aScriptor playerScripted; 
			makeGetter: nil from: aScriptor playerScripted costume 
			forPart: (Array with: instVar with: #number).	"makes a new Phrase"
		^ pm].

	(#(ifTrue:ifFalse: ifFalse: ifTrue:) includes: sel) ifTrue: [
		^ CompoundTileMorph new tilesFrom: msgNode in: aScriptor].

	self addMorphBack: (TilePadMorph new tilesFrom: msgNode receiver in: aScriptor).
	self addMorphBack: (TileMorph new selectorTile: msgNode in: aScriptor).	"selector"
	(aScriptor playerScripted elementTypeFor: sel) == #systemScript ifTrue: [
		selType _ (aScriptor playerScripted phraseSpecFor: 
			(Array with: #command with: sel)) last].
	msgNode arguments size > 0 ifTrue: [
		argNode _ msgNode arguments last.
		tile _ TileMorph new tilesFrom: argNode type: selType in: aScriptor.
		self addMorphBack: tile].
