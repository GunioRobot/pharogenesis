commandPhraseFor: commandSpec inViewer: aViewer
	"Translate commandSpec into a PhraseTileMorph.  Put balloon help into the phrase.  This work derives from the original e-toy work, where its code was specific to the Player/Morph architecture; it is now elevated to class Object, but really only reliably works when the viewee is indeed  a Player."

	| aRow resultType cmd argType argTile selfTile aPhrase balloonTextSelector stat inst |

	resultType _ (commandSpec at: 1).
	cmd _ (commandSpec at: 2).
	commandSpec size = 3
		ifTrue:
			[aPhrase _ PhraseTileMorph new setOperator: cmd
				type: resultType
				rcvrType: #player]
		ifFalse: "commandSpec size is four"
			[argType _ commandSpec at: 4.
			aPhrase _ PhraseTileMorph new setOperator: cmd
				type: resultType
				rcvrType: #player
				argType: argType.
			argTile _ self tileForArgType: argType inViewer: aViewer.
			argTile position: aPhrase lastSubmorph position.
			aPhrase lastSubmorph addMorph: argTile].

	(self belongsToUniClass and:
			[self class includesSelector: cmd])
		ifTrue: [balloonTextSelector _ #userScript].

	aPhrase operatorTile balloonTextSelector: (balloonTextSelector ifNil: [cmd]).
	aPhrase markAsPartsDonor.

	selfTile _ aViewer tileForSelf.
	selfTile position: aPhrase firstSubmorph position.
	aPhrase firstSubmorph addMorph: selfTile.

	aRow _ ViewerRow newRow borderWidth: 0; color: aViewer color.
	aRow elementSymbol: cmd asSymbol.

	aRow addMorphBack: (ScriptingSystem tryButtonFor: aPhrase).
	aRow addMorphBack: (Morph new extent: 4@2; beTransparent).
	aRow addMorphBack: (aViewer infoButtonFor: cmd).
	aRow addMorphBack: aPhrase.
	false "(names includes: cmd)" ifTrue:
		[aPhrase userScriptSelector: cmd.
		aPhrase beTransparent.
		aRow addMorphBack: AlignmentMorph newVariableTransparentSpacer.
		aRow addMorphBack: (stat _ (inst _ self scriptInstantiationForSelector: cmd) statusControlMorph).
		inst updateStatusMorph: stat.].

	aRow beSticky; disableDragNDrop.

	^ aRow