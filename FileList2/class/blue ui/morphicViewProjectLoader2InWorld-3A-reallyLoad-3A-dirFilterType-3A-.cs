morphicViewProjectLoader2InWorld: aWorld reallyLoad: aBoolean dirFilterType: aSymbol

	| window aFileList buttons treePane textColor1 fileListPane pane2a pane2b treeExtent filesExtent |

	window _ AlignmentMorphBob1 newColumn.
	window hResizing: #shrinkWrap; vResizing: #shrinkWrap.
	textColor1 _ Color r: 0.742 g: 0.839 b: 1.0.
	aFileList _ self new directory: FileDirectory default.
	aFileList 
		optionalButtonSpecs: aFileList servicesForProjectLoader;
		fileSelectionBlock: (
			aSymbol == #limitedSuperSwikiDirectoryList ifTrue: [
				MessageSend receiver: self selector: #projectOnlySelectionMethod:
			] ifFalse: [
				self projectOnlySelectionBlock
			]
		);
		"dirSelectionBlock: self hideSqueakletDirectoryBlock;"
		modalView: window.
	window
		setProperty: #FileList toValue: aFileList;
		wrapCentering: #center; cellPositioning: #topCenter;
		borderWidth: 4;
		borderColor: (Color r: 0.355 g: 0.516 b: 1.0);
		useRoundedCorners.
	buttons _ #('OK' 'Cancel') collect: [ :each |
		self blueButtonText: each textColor: textColor1 inWindow: window
	].
	aWorld width < 800 ifTrue: [
		treeExtent _ 150@300.
		filesExtent _ 350@300.
	] ifFalse: [
		treeExtent _ 250@300.
		filesExtent _ 350@300.
	].
	(treePane _ aFileList morphicDirectoryTreePaneFiltered: aSymbol)
		extent: treeExtent; 
		retractable: false;
		borderWidth: 0.
	fileListPane _ aFileList morphicFileListPane 
		extent: filesExtent; 
		retractable: false;
		borderWidth: 0.
	window
		addARow: {
			window fancyText: 'Load A Project' translated ofSize: 21 color: textColor1
		};
		addARowCentered: {
			buttons first. 
			(Morph new extent: 30@5) color: Color transparent. 
			buttons second
		};
		addARow: {
			window fancyText: 'Please select a project' translated ofSize: 21 color: Color blue
		};
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
	buttons first 
		on: #mouseUp 
		send: (aBoolean ifTrue: [#okHitForProjectLoader] ifFalse: [#okHit])
		to: aFileList.
	buttons second on: #mouseUp send: #cancelHit to: aFileList.
	aFileList postOpen.
	window position: aWorld topLeft + (aWorld extent - window extent // 2).
	window adoptPaneColor: (Color r: 0.548 g: 0.677 b: 1.0).
	^ window openInWorld: aWorld.