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
		borderWidth: 4;
		borderColor: (Color r: 0.355 g: 0.516 b: 1.0);
		useRoundedCorners.
	buttonData _ Preferences enableLocalSave
		ifTrue: [#( 
			('Save' okHit 'Save in the place specified below, and in the 
	Squeaklets folder on your local disk') 
			('Save on local disk only' saveLocalOnlyHit 'saves in the Squeaklets folder')
			('Cancel' cancelHit 'return without saving') 
			)]
		ifFalse: [#( 
			('Save' okHit 'Save in the place specified below, and in the 
	Squeaklets folder on your local disk') 
			('Cancel' cancelHit 'return without saving') 
			)].
	buttons _ buttonData collect: [ :each |
		(self blueButtonText: each first translated textColor: textColor1 inWindow: window)
			setBalloonText: each third translated;
			hResizing: #shrinkWrap;
			on: #mouseUp send: each second to: aFileList
	].
	option _ aProject world 
		valueOfProperty: #SuperSwikiPublishOptions 
		ifAbsent: [#initialDirectoryList].
	aProject world removeProperty: #SuperSwikiPublishOptions.

	World height < 500 ifTrue: [
		treeExtent _ 350@150.
	] ifFalse: [
		treeExtent _ 350@300.
	].

	(treePane _ aFileList morphicDirectoryTreePaneFiltered: option) 
		extent: treeExtent; 
		retractable: false;
		borderWidth: 0.
	window
		addARowCentered: {
			window fancyText: 'Publish This Project' translated ofSize: 21 color: textColor1
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
			window fancyText: 'Please select a folder' translated ofSize: 21 color: Color blue
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
	window adoptPaneColor: (Color r: 0.548 g: 0.677 b: 1.0).
	^ window 