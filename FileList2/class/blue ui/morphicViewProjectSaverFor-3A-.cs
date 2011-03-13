morphicViewProjectSaverFor: aProject
"
(FileList2 morphicViewProjectSaverFor: Project current) openInWorld
"
	| window aFileList buttons treePane pane2 textColor1 |

	textColor1 _ Color r: 0.742 g: 0.839 b: 1.0.
	aFileList _ self new directory: FileDirectory default.
	aFileList dirSelectionBlock: self hideSqueakletDirectoryBlock.
	window _ AlignmentMorphBob1 newColumn.
	window hResizing: #shrinkWrap; vResizing: #shrinkWrap.
	aFileList modalView: window.
	window
		setProperty: #FileList toValue: aFileList;
		wrapCentering: #center; cellPositioning: #topCenter;
		borderWidth: 4;
		borderColor: (Color r: 0.355 g: 0.516 b: 1.0);
		useRoundedCorners.
	buttons _ #( ('OK' okHit) ('Cancel' cancelHit) ) collect: [ :each |
		(self blueButtonText: each first textColor: textColor1 inWindow: window)
			on: #mouseUp send: each second to: aFileList
	].
	treePane _ aFileList morphicDirectoryTreePane 
		extent: 350@300; 
		retractable: false;
		borderWidth: 0.
	window
		addARowCentered: {
			window fancyText: 'Publish This Project' ofSize: 21 color: textColor1
		};
		addARowCentered: {
			buttons first. 
			(Morph new extent: 30@5) color: Color transparent. 
			buttons second
		};
		addARowCentered: { (window inAColumn: {(ProjectViewMorph on: aProject) lock}) layoutInset: 4};
		addARowCentered: {
			window fancyText: 'Please select a folder' ofSize: 21 color: Color blue
		};
		addARow: {
			(
				window inAColumn: {
					(pane2 _ window inARow: {window inAColumn: {treePane}}) 
						useRoundedCorners; layoutInset: 6
				}
			) layoutInset: 10
		}.
	window fullBounds.
	window fillWithRamp: self blueRamp1 oriented: 0.65.
	pane2 fillWithRamp: self blueRamp3 oriented: (0.7 @ 0.35).
	buttons do: [ :each |
		each fillWithRamp: self blueRamp2 oriented: (0.75 @ 0).
	].
	window setProperty: #morphicLayerNumber toValue: 11.
	aFileList postOpen.
	^ window 