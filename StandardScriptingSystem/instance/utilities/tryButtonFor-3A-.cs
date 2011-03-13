tryButtonFor: aPhraseTileMorph
	| aButton |
	aButton _ SimpleButtonMorph new.
	aButton target: aPhraseTileMorph; actionSelector: #try; label: '!' font: (StrikeFont familyName: #ComicBold size: 16); color: Color yellow; borderWidth: 0.
	aButton actWhen: #whilePressed.
	aButton balloonTextSelector: #try.
	^ aButton