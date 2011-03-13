tilesFrom: msgNode in: aScriptor
	"Construct a single line of tiles from a MessageNode of a parse tree.  For a single message send."

	| tile pm sel instVar suff argNode selType |

	self flag: #noteToTed.  "Ted: this is your code from 8/6/99, which is now broken before it could ever get used.  The method #scriptInfoFor: which it formerly called is gone; I've included its old content at the end in comments as a pointer.  sw 9/8/2000 09:44"
	"latter-day note: sw 10/10/2000 11:25 - this is now reached by the from a menu item in the Scriptor menu, so this is where the capability needs to be revived"
	true ifTrue: [^ self inform: 'Under Construction!
Not yet released!.
(sorry)'].

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


"Old code from Player, now superseded by an entirely new mechanism...
phraseSpecFor: aPair
	| info prefix |
	info _ (prefix _ aPair first) == #slot
		ifTrue:
			[ScriptingSystem slotInfoFor: aPair second]
		ifFalse:
			[ScriptingSystem scriptInfoFor: aPair second].
	^ (Array with: prefix), info"
