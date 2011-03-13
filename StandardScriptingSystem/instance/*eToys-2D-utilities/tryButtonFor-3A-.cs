tryButtonFor: aPhraseTileMorph 
	| aButton |
	aButton := SimpleButtonMorph new.
	aButton target: aPhraseTileMorph;
		 actionSelector: #try;
		
		label: '!'
		font: Preferences standardEToysFont;
		 color: Color yellow;
		 borderWidth: 0.
	aButton actWhen: #whilePressed.
	aButton balloonTextSelector: #try.
	^ aButton