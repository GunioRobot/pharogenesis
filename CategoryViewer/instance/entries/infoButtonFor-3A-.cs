infoButtonFor: aScriptOrSlotSymbol
	| aButton balloonTextSelector |
	balloonTextSelector _ nil.
	(scriptedPlayer slotInfo includesKey: aScriptOrSlotSymbol asSymbol)
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
	aButton balloonTextSelector: (balloonTextSelector ifNil: [aScriptOrSlotSymbol]).
	^ aButton