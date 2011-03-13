infoButtonFor: aScriptOrSlotSymbol
	"Answer a fully-formed morph that will serve as the 'info button' alongside an entry corresponding to the given slot or script symbol"

	| aButton balloonTextSelector |
	balloonTextSelector _ nil.
	((scriptedPlayer isKindOf: Player) and: [scriptedPlayer slotInfo includesKey: aScriptOrSlotSymbol asSymbol])
		ifTrue: [balloonTextSelector _ #userSlot].

	(scriptedPlayer belongsToUniClass and:
			[scriptedPlayer class includesSelector: aScriptOrSlotSymbol])
		ifTrue: [balloonTextSelector _ #userScript].

	aButton _ SimpleButtonMorph new.
	aButton target: scriptedPlayer;
		actionSelector: #infoFor:inViewer:;
		arguments: (Array with: aScriptOrSlotSymbol with: self);
		label: '¥' font: (StrikeFont familyName: #ComicBold size: 12);
		color: Color transparent;
		borderWidth: 0;
		actWhen: #buttonDown.
	balloonTextSelector
		ifNotNil:	[aButton balloonTextSelector: balloonTextSelector]
		ifNil:		[aButton setBalloonText: 'Press here to get a menu'].
	^ aButton