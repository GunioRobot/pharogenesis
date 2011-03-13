addHeaderMorph
	"Add the header at the top of the viewer, with a control for choosing the category, etc."

	| header aFont aButton wrpr |
	header _ AlignmentMorph newRow color: self color; wrapCentering: #center; cellPositioning: #leftCenter.
	aFont _ Preferences standardButtonFont.
	header addMorph: (aButton _ SimpleButtonMorph new label: 'O' font: aFont).
	aButton target: self;
			color:  Color tan;
			actionSelector: #delete;
			setBalloonText: 'remove this pane from the screen
don''t worry -- nothing will be lost!.'.
	header addTransparentSpacerOfSize: 5@5.

	header addUpDownArrowsFor: self.
	(wrpr _ header submorphs last) submorphs second setBalloonText: 'previous category'.	
	wrpr submorphs first  setBalloonText: 'next category'.
	header beSticky.
	self addMorph: header.

	namePane _ RectangleMorph newSticky color: Color brown veryMuchLighter.
	namePane borderWidth: 0.
	aButton _ (StringButtonMorph contents: '-----' font: (StrikeFont familyName: #NewYork size: 12)) color: Color black.
	aButton target: self; arguments: Array new; actionSelector: #chooseCategory.
	aButton actWhen: #buttonDown.
	namePane addMorph: aButton.
	aButton position: namePane position.
	namePane align: namePane topLeft with: (bounds topLeft + (50 @ 0)).
	namePane setBalloonText: 'category (click here to choose a different one)'.

	header addMorphBack: namePane.
	(namePane isKindOf: RectangleMorph) ifTrue:
		[namePane addDropShadow.
		namePane shadowColor: Color gray].

	self categoryChoice: #basic