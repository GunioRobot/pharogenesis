scrapsBook
	| header aButton label |
	ScrapsBook ifNil:
		[ScrapsBook _ BookMorph new pageSize: 200@300; setNameTo: 'scraps'.
		ScrapsBook color: Color yellow muchLighter.
		ScrapsBook borderColor: Color darkGray; borderWidth: 2.
		ScrapsBook removeEverything; showPageControls; insertPage.
		header _ AlignmentMorph newRow centering: #center.
		header setProperty: #header toValue: true.
		header addMorph: (aButton _ SimpleButtonMorph new label: 'X' font: Preferences standardButtonFont).
		aButton target: ScrapsBook; color:  Color lightRed; actionSelector: #delete;
				setBalloonText: 'Remove
(to view again later, click on any trashcan).'.

		header addMorphBack: AlignmentMorph newVariableTransparentSpacer beSticky.
		header addMorphBack: 	(label _ UpdatingStringMorph new target: self) beSticky.
		label getSelector: #trashTitle; useStringFormat; step.
		header addMorphBack: AlignmentMorph newVariableTransparentSpacer beSticky.
		header addMorphBack: (aButton _ SimpleButtonMorph new label: 'E' font: Preferences standardButtonFont).
		aButton target: Utilities; color:  Color veryLightGray; actionSelector: #maybeEmptyTrash;
				setBalloonText: 'Click here to empty the trash.'.
		ScrapsBook currentPage addMorph: (TextMorph new contents: 'Objects you drag into the trash will automatically be saved here, one object per page, in case you need them later.  To disable this feature set the "preserveTrash" Preference to false.

You can individually expunge objects by hitting the - control, and you can empty out all the objects in the trash can by hitting the "E" button at top right.'
			wrappedTo: 190).

		ScrapsBook addMorphFront: header.
		ScrapsBook setProperty: #scraps toValue: true].
	^ ScrapsBook

	"Utilities emptyScrapsBook"
