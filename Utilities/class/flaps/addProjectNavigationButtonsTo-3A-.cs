addProjectNavigationButtonsTo: aMorph
	"Add prev, next, and go-to buttons at the top of aMorph"

	| aButton aFont |
	aButton _ SimpleButtonMorph new target: Project.
	aButton actionSelector: #returnToPreviousProject.
	aFont _ StrikeFont familyName: #ComicBold size: 24.
	aButton label: '<' font: aFont; borderWidth: 0.
	aButton firstSubmorph color: Color red lighter.
	aButton beTransparent.
	aButton position: 30 @ 12.
	aButton setBalloonText: 'previous project'.
	aMorph addMorph: aButton.

	aButton _ aButton fullCopy.
	aButton actionSelector: #advanceToNextProject.
	aButton label: '>' font: aFont; borderWidth: 0.
	aButton firstSubmorph color: Color red lighter.
	aButton position: 150 @ 14.
	aButton setBalloonText: 'next project'.
	aMorph addMorph: aButton.

	aButton _ aButton fullCopy actWhen: #buttonDown.
	aButton actionSelector: #jumpToProject; target: self currentHand.
	aButton label: 'Go...' font: (StrikeFont familyName: #ComicBold size: 19); borderWidth: 0.
	aButton position: 78 @ 16.
	aButton firstSubmorph color: Color red lighter.
	aButton setBalloonText: 'go directly to a project'.
	aMorph addMorph: aButton