morphicViewGeneralLoaderInWorld: aWorld
"
FileList2 morphicViewGeneralLoaderInWorld: self currentWorld
"
	| window aFileList buttons treePane textColor1 fileListPane pane2a pane2b fileTypeInfo fileTypeButtons fileTypeRow actionRow |

	fileTypeInfo _ self endingSpecs.
	window _ AlignmentMorphBob1 newColumn.
	window hResizing: #shrinkWrap; vResizing: #shrinkWrap.
	textColor1 _ Color r: 0.742 g: 0.839 b: 1.0.
	aFileList _ self new directory: FileDirectory default.
	aFileList 
		fileSelectionBlock: self projectOnlySelectionBlock;
		modalView: window.
	window
		setProperty: #FileList toValue: aFileList;
		wrapCentering: #center; cellPositioning: #topCenter;
		borderWidth: 4;
		borderColor: (Color r: 0.355 g: 0.516 b: 1.0);
		useRoundedCorners.

	fileTypeButtons _ fileTypeInfo collect: [ :each |
		(self blueButtonText: each first textColor: Color gray inWindow: window)
			setProperty: #enabled toValue: true;
			hResizing: #shrinkWrap
	].
	buttons _ #('OK' 'Cancel') collect: [ :each |
		self blueButtonText: each textColor: textColor1 inWindow: window
	].
	treePane _ aFileList morphicDirectoryTreePane 
		extent: 250@300; 
		retractable: false;
		borderWidth: 0.
	fileListPane _ aFileList morphicFileListPane 
		extent: 350@300; 
		retractable: false;
		borderWidth: 0.
	window addARow: {window fancyText: 'Find...' translated ofSize: 21 color: textColor1}.
	fileTypeRow _ window addARowCentered: fileTypeButtons.
	actionRow _ window addARowCentered: {
		buttons first. 
		(Morph new extent: 30@5) color: Color transparent. 
		buttons second
	}.
	window
		addARow: {
			(window inAColumn: {(pane2a _ window inARow: {window inAColumn: {treePane}}) 
				useRoundedCorners; layoutInset: 6}) layoutInset: 10.
			(window inAColumn: {(pane2b _ window inARow: {window inAColumn: {fileListPane}}) 
				useRoundedCorners; layoutInset: 6}) layoutInset: 10.
		}.
	window fullBounds.
	window fillWithRamp: self blueRamp1 oriented: 0.65.
	pane2a fillWithRamp: self blueRamp3 oriented: (0.7 @ 0.35).
	pane2b fillWithRamp: self blueRamp3 oriented: (0.7 @ 0.35).
	buttons do: [ :each |
		each fillWithRamp: self blueRamp2 oriented: (0.75 @ 0).
	].
	fileTypeButtons do: [ :each | 
		each 
			on: #mouseUp 
			send: #value:value: 
			to: [ :evt :morph | 
				self update: actionRow in: window fileTypeRow: fileTypeRow morphUp: morph.
			] fixTemps
	].
	buttons first on: #mouseUp send: #okHit to: aFileList.
	buttons second on: #mouseUp send: #cancelHit to: aFileList.
	aFileList postOpen.
	window position: aWorld topLeft + (aWorld extent - window extent // 2).
	aFileList directoryChangeBlock: [ :newDir |
		self enableTypeButtons: fileTypeButtons info: fileTypeInfo forDir: newDir
	] fixTemps.
	aFileList directory: aFileList directory.
	window adoptPaneColor: (Color r: 0.548 g: 0.677 b: 1.0).
	^ window openInWorld: aWorld.