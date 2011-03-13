morphicViewFolderSelector

	| dir aFileList window fixedSize |

	dir _ FileDirectory default.
	aFileList _ self new directory: dir.
	aFileList optionalButtonSpecs: self specsForFolderSelector.
	window _ (SystemWindow labelled: dir pathName) model: aFileList.
	aFileList modalView: window.

	fixedSize _ 25.
	self addFullPanesTo: window from: {
		{self textRow: 'Please select a folder'. 0 @ 0 corner: 1 @ 0. 
				0@0 corner: 0@fixedSize}.
		{aFileList optionalButtonRow. 0 @ 0 corner: 1 @ 0. 
				0@fixedSize corner: 0@(fixedSize * 2)}.
		{aFileList morphicDirectoryTreePane. 0@0 corner: 1@1.
				0@(fixedSize * 2) corner: 0@0}.
	}.
	aFileList postOpen.
	^ window 