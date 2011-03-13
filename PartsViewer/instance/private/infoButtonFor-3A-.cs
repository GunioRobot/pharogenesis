infoButtonFor: aSlotName
	| aButton isUserSlot |

	isUserSlot _ scriptedPlayer slotInfo includesKey: aSlotName asSymbol.
	aButton _ SimpleButtonMorph new.
	aButton target: scriptedPlayer;
		actionSelector: #infoFor:;
		arguments: (Array with: aSlotName);
		label: '?' font: (StrikeFont familyName: #ComicBold size: 16);
		color: Color transparent;
		borderWidth: 0;
		actWhen: #buttonDown.
	aButton balloonTextSelector: (isUserSlot
		ifFalse:	[aSlotName]
		ifTrue:	[#userSlot]).
	^ aButton