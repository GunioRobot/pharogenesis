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
		borderWidth: ColorTheme current dialogBorderWidth;
		borderColor: ColorTheme current dialogBorderColor;
		useRoundedCorners.

	fileTypeButtons _ fileTypeInfo collect: [ :each |
		(self blueButtonText: each first textColor: Color gray inWindow: window)
			setProperty: #enabled toValue: true;
			hResizing: #shrinkWrap;
			useSquareCorners
	].
	buttons _ {{'OK'. ColorTheme current okColor}. {'Cancel'. ColorTheme current cancelColor}} collect: [ :each |
		self blueButtonText: each first textColor: textColor1 color: each second inWindow: window
	].

	treePane _ aFileList morphicDirectoryTreePane 
		extent: 250@300; 
		retractable: false;
		borderWidth: 0.
	fileListPane _ aFileList morphicFileListPane 
		extent: 350@300; 
		retractable: false;
		borderWidth: 0.
	window addARow: {window fancyText: 'Find...' translated font: Preferences standardEToysTitleFont color: textColor1}.
	fileTypeRow _ window addARowCentered: fileTypeButtons cellInset: 2.
	actionRow _ window addARowCentered: {
		buttons first. 
		(Morph new extent: 30@5) color: Color transparent. 
		buttons second
	} cellInset: 2.
	window
		addARow: {
				(window inAColumn: {(pane2a _ window inARow: {window inAColumn: {treePane}}) 
					useRoundedCorners;
					layoutInset: 0;
					borderWidth: ColorTheme current dialogPaneBorderWidth;
					borderColor: ColorTheme current dialogPaneBorderColor
				}) layoutInset: 10.
				(window inAColumn: {(pane2b _ window inARow: {window inAColumn: {fileListPane}}) 
					useRoundedCorners;
					layoutInset: 0;
					borderWidth: ColorTheme current dialogPaneBorderWidth;
					borderColor: ColorTheme current dialogPaneBorderColor
				}) layoutInset: 10.
		}.
	window fullBounds.
	window fillWithRamp: ColorTheme current dialogRampOrColor oriented: 0.65.
	pane2a fillWithRamp: ColorTheme current dialogPaneRampOrColor oriented: (0.7 @ 0.35).
	pane2b fillWithRamp: ColorTheme current dialogPaneRampOrColor oriented: (0.7 @ 0.35).
"
	buttons do: [ :each |
		each fillWithRamp: ColorTheme current dialogButtonsRampOrColor oriented: (0.75 @ 0).
	].
"
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
		self update: actionRow in: window fileTypeRow: fileTypeRow morphUp: nil.
		self enableTypeButtons: fileTypeButtons info: fileTypeInfo forDir: newDir.
	] fixTemps.
	aFileList directory: aFileList directory.
	window adoptPaneColor: (Color r: 0.548 g: 0.677 b: 1.0).
	window becomeModal.
	^ window openInWorld: aWorld.