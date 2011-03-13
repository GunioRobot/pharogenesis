morphicViewProjectSaverFor: aProject
"
(FileList2 morphicViewProjectSaverFor: Project current) openInWorld
"
	| window aFileList buttons treePane pane2 textColor1 option treeExtent buttonData buttonRow |

	textColor1 _ Color r: 0.742 g: 0.839 b: 1.0.
	aFileList _ self new directory: ServerDirectory projectDefaultDirectory.
	aFileList dirSelectionBlock: self hideSqueakletDirectoryBlock.
	window _ AlignmentMorphBob1 newColumn.
	window hResizing: #shrinkWrap; vResizing: #shrinkWrap.
	aFileList modalView: window.
	window
		setProperty: #FileList toValue: aFileList;
		wrapCentering: #center; cellPositioning: #topCenter;
		borderWidth: ColorTheme current dialogBorderWidth;
		borderColor: ColorTheme current dialogBorderColor;
		useRoundedCorners.

	buttonData := Preferences enableLocalSave
				ifTrue: [{
							{'Save'. #okHit. 'Save in the place specified below, and in the Squeaklets folder on your local disk'. ColorTheme current okColor}.
							{'Save on local disk only'. #saveLocalOnlyHit. 'saves in the Squeaklets folder'. ColorTheme current okColor}.
							{'Cancel'. #cancelHit. 'return without saving'. ColorTheme current cancelColor}
						}]
				ifFalse: [{
							{'Save'. #okHit. 'Save in the place specified below, and in the Squeaklets folder on your local disk'. ColorTheme current okColor}.
							{'Cancel'. #cancelHit. 'return without saving'. ColorTheme current cancelColor}
						}].
	buttons _ buttonData collect: [ :each |
		(self blueButtonText: each first textColor: textColor1 color: each fourth inWindow: window)
			setBalloonText: each third translated;
			hResizing: #shrinkWrap;
			on: #mouseUp send: each second to: aFileList
	].

	option _ aProject world 
		valueOfProperty: #SuperSwikiPublishOptions 
		ifAbsent: [#initialDirectoryList].
	aProject world removeProperty: #SuperSwikiPublishOptions.

	treeExtent _ World height < 500
						ifTrue: [ 350@150 ]
						ifFalse: [ 350@300 ].

	(treePane _ aFileList morphicDirectoryTreePaneFiltered: option) 
		extent: treeExtent; 
		retractable: false;
		borderWidth: 0.
	window
		addARowCentered: {
			window fancyText: 'Publish This Project' translated font: Preferences standardEToysTitleFont color: textColor1
		}.
	buttonRow _ OrderedCollection new.
	buttons do: [:button | buttonRow add: button] separatedBy: [buttonRow add: ((Morph new extent: 30@5) color: Color transparent)].

"	addARowCentered: {
			buttons first. 
			(Morph new extent: 30@5) color: Color transparent. 
			buttons second.
			(Morph new extent: 30@5) color: Color transparent. 
			buttons third
		};"
	window
		addARowCentered: buttonRow;
		addARowCentered: { (window inAColumn: {(ProjectViewMorph on: aProject) lock}) layoutInset: 4};
		addARowCentered: {
			window fancyText: 'Please select a folder' translated font: Preferences standardEToysFont color: textColor1
		};
		addARow: {
			(
				window inAColumn: {
					(pane2 _ window inARow: {window inAColumn: {treePane}}) 
						useRoundedCorners;
						layoutInset: 0;
						borderWidth: ColorTheme current dialogPaneBorderWidth;
						borderColor: ColorTheme current dialogPaneBorderColor
				}
			) layoutInset: 10
		}.
	window fullBounds.
	window fillWithRamp: ColorTheme current dialogRampOrColor oriented: 0.65.
	pane2 fillWithRamp: ColorTheme current dialogPaneRampOrColor oriented: (0.7 @ 0.35).
"
	buttons do: [ :each |
		each fillWithRamp: ColorTheme current dialogButtonsRampOrColor oriented: (0.75 @ 0).
	].
"
	window setProperty: #morphicLayerNumber toValue: 11.
	aFileList postOpen.
	window adoptPaneColor: (Color r: 0.548 g: 0.677 b: 1.0).
	^ window 