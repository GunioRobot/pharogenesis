addHeaderMorph
	| header aFont aButton wrpr |
	header _ AlignmentMorph newRow color: self color; centering: #center.
	aFont _ Preferences standardButtonFont.
	header addMorph: (aButton _ SimpleButtonMorph new label: 'X' font: aFont).
	aButton target: self;
			color:  Color lightRed;
			actionSelector: #delete;
			setBalloonText: 'Delete this pane'.
	header addTransparentSpacerOfSize: 5@5.

	Preferences useCategoryListsInViewers
		ifFalse:
			[header addUpDownArrowsFor: self.
			(wrpr _ header submorphs last) submorphs second setBalloonText: 'previous category'.	
			wrpr submorphs first  setBalloonText: 'next category'].
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
		namePane owner color: Color gray].

	self categoryChoice: 'basic'