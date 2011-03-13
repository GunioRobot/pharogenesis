initializeFor: aTarget withForms: formList coexist: aBoolean
	" World primaryHand attachMorph: (GraphicalMenu new initializeFor: nil 
		withForms: Form allInstances coexist: true) "
	| buttons b anIndex buttonCage imageWrapper |
	target _ aTarget.
	coexistWithOriginal _ aBoolean.
	color _ Color white.
	borderColor _ Color blue darker.
	borderWidth _ 1.
	formChoices _ formList.
	currentIndex _ 1.
	self hResizing: #shrinkWrap; vResizing: #shrinkWrap.

	b _ SimpleButtonMorph new target: self; borderColor: Color black.

	buttons _ AlignmentMorph newRow.
	buttons borderWidth: 0; layoutInset: 0.
	buttons hResizing: #shrinkWrap; vResizing: #shrinkWrap; extent: 5@5.
	buttons wrapCentering: #topLeft.
	buttonCage _ AlignmentMorph newColumn.
	buttonCage hResizing: #shrinkWrap; vResizing: #spaceFill.
	buttonCage addTransparentSpacerOfSize: (0 @ 10).

	buttons addMorphBack: (b fullCopy label: 'Prev';	actionSelector: #downArrowHit; actWhen: #whilePressed).
	buttons addTransparentSpacerOfSize: (9@0).
	buttons addMorphBack: (b fullCopy label: 'Next';	actionSelector: #upArrowHit; actWhen: #whilePressed).
	buttons addTransparentSpacerOfSize: (5@0).

	buttons submorphs last color: Color white.
	buttonCage addMorphBack: buttons.
	buttonCage addTransparentSpacerOfSize: (0 @ 12).
	buttons _ AlignmentMorph newRow.
	buttons addMorphBack: (b fullCopy label: 'OK';	actionSelector: #okay).
	buttons addTransparentSpacerOfSize: (5@0).
	buttons addMorphBack: (b fullCopy label: 'Cancel';	actionSelector: #cancel).
	buttonCage addMorphBack: buttons.
	buttonCage addTransparentSpacerOfSize: (0 @ 10).
	self addMorphFront: buttonCage.

	imageWrapper _ Morph new color: Color transparent; extent: 102 @ 82.
	imageWrapper addMorphBack: (formDisplayMorph _ ImageMorph new extent: 100 @ 100).
	self addMorphBack: imageWrapper.
	target ifNotNil: [(anIndex _ formList indexOf: target form ifAbsent: [nil]) ifNotNil:
		[currentIndex _ anIndex]].
	self updateThumbnail