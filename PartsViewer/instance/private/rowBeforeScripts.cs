rowBeforeScripts

	| r aButton aFont |
	r _ AlignmentMorph newRow color: self color; centering: #center.

	aButton _ SimpleButtonMorph new target: self; actionSelector: #previousScriptsBank; label: '<' font: (StrikeFont familyName: #ComicBold size: 16); color: self caretColor; borderWidth: 0; actWhen: #buttonUp.
	r addMorphBack: aButton.
	aButton setBalloonText: 'show previous bank of scripts'.	
	r addTransparentSpacerOfSize: 5@5.

	aButton _ SimpleButtonMorph new target: self; actionSelector: #nextScriptsBank; label: '>' font: (StrikeFont familyName: #ComicBold size: 16); color: self caretColor; borderWidth: 0; actWhen: #buttonUp.
	aButton setBalloonText: 'show next bank of scripts'.	
	r addMorphBack: aButton.
	r addTransparentSpacerOfSize: 18@5.

	aButton _ SimpleButtonMorph new target: self; actionSelector: #newEmptyScript; label: 'add script' font: (aFont _ StrikeFont familyName: #ComicBold size: 16); color: self caretColor; borderWidth: 0; actWhen: #buttonDown.
	aButton setBalloonText: 'drag from here to
create a new script
for this object'.	
	r addMorphBack: aButton.
	r addTransparentSpacerOfSize: 18@5.

	aButton _ SimpleButtonMorph new target: scriptedPlayer; actionSelector: #addInstanceVariable; label: 'add inst var' font: aFont; color: self caretColor; borderWidth: 0; actWhen: #buttonUp.
	aButton setBalloonText: 'click here to add
an instance variable
to this object.'.
	r addMorphBack: aButton.

	^ r