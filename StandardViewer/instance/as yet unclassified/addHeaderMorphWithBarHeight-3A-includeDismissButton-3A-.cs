addHeaderMorphWithBarHeight: anInteger includeDismissButton: aBoolean
	| header aFont aButton aTextMorph nail wrpr costs headWrapper inner |
	header _ AlignmentMorph newRow color: self color muchLighter; centering: #center.
	aFont _ Preferences standardButtonFont.
	aBoolean ifTrue:
		[header addMorph: (aButton _ SimpleButtonMorph new label: 'X' font: aFont).
		aButton target: self;
				color:  Color lightRed;
				actionSelector: #dismiss;
				setBalloonText: 'Delete this entire Viewer'.
		header addTransparentSpacerOfSize: 4@1].

	aButton _ IconicButton new borderWidth: 0;
			labelGraphic: (ScriptingSystem formAtKey: #AddCategoryViewer); color: Color transparent; 
			actWhen: #buttonDown;
			target: self;
			actionSelector: #addCategoryViewer;
			setBalloonText: 'click here to add
another category pane';
			shedSelvedge.
	header addMorphBack: aButton.
	header addTransparentSpacerOfSize: 4@1.

	costs _ scriptedPlayer costumes.
	costs ifNotNil:
	[(costs size > 1 or: [costs size = 1 and: [costs first ~~ scriptedPlayer costume]]) ifTrue:
		[header addUpDownArrowsFor: self.
		(wrpr _ header submorphs last) submorphs second setBalloonText: 'switch to previous costume'.	
		wrpr submorphs first  setBalloonText: 'switch to next costume']].	

	(self hasProperty: #noInteriorThumbnail)
		ifFalse:
			[nail _ ThumbnailMorph new objectToView: scriptedPlayer viewSelector: #costume]
		ifTrue:
			[inner _ ImageMorph new image: (ScriptingSystem formAtKey: 'Menu').
			nail _ RectangleMorph new beTransparent extent: inner extent.
			nail addMorph: inner lock].
	nail on: #mouseDown send: #thumbnailMenuEvt:forMorph: to: scriptedPlayer.
	header addMorphBack: nail.
	nail setBalloonText: 'click here to get a menu
that will allow you to
add an instance variable,,
tear off a tile, etc..'.
	(self hasProperty: #noInteriorThumbnail)
		ifFalse:
			[nail borderWidth: 3; borderColor: #raised].

	header addTransparentSpacerOfSize: 5@5.

"	aButton _ SimpleButtonMorph new target: self; actionSelector: #newEmptyScript; label: 'S' font: (aFont _ StrikeFont familyName: #ComicBold size: 16);  color: Color transparent; borderWidth: 0; actWhen: #buttonDown.
	aButton setBalloonText: 'drag from here to
create a new script
for this object'.	
	header addMorphBack: aButton.

	header addTransparentSpacerOfSize: 8@5.

	aButton _ SimpleButtonMorph new target: scriptedPlayer; actionSelector: #addInstanceVariable; label: 'I' font: aFont;  color: Color transparent; borderWidth: 0; actWhen: #buttonUp.
	aButton setBalloonText: 'click here to add
an instance variable
to this object.'.
	header addMorphBack: aButton.

	header addTransparentSpacerOfSize: 5@5."

	scriptedPlayer costume assureExternalName.
	aTextMorph _ UpdatingStringMorph new
		useStringFormat;
		target:  scriptedPlayer;
		getSelector: #getName;
		putSelector: #setName:;
		setNameTo: 'name';
		font: ScriptingSystem fontForNameEditingInScriptor.
	aTextMorph setProperty: #okToTextEdit toValue: true.
	aTextMorph step.
	header  addMorphBack: aTextMorph.
	aTextMorph setBalloonText: 'Click here to edit the player''s name.'.	

	header beSticky.
	anInteger > 0
		ifTrue:
			[headWrapper _ AlignmentMorph newColumn color: self color.
			headWrapper addTransparentSpacerOfSize: (0 @ anInteger).
			headWrapper addMorphBack: header.
			self addMorph: headWrapper]
		ifFalse:
			[self addMorph: header]