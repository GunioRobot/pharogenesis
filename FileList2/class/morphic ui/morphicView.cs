morphicView

	| dir aFileList window fileListBottom midLine fileListTopOffset |

	dir _ FileDirectory default.
	aFileList _ self new directory: dir.
	window _ (SystemWindow labelled: dir pathName) model: aFileList.

	fileListTopOffset _ 25.
	fileListBottom _ 0.4.
	midLine _ 0.4.
	self addFullPanesTo: window from: {
		{aFileList morphicPatternPane. 0@0 corner: 0.3@0. 0@0 corner: 0@fileListTopOffset}.
		{aFileList optionalButtonRow. 0.3 @ 0 corner: 1 @ 0. 0@0 corner: 0@fileListTopOffset}.
		{aFileList morphicDirectoryTreePane. 0@0 corner: midLine@fileListBottom. 
					0@fileListTopOffset corner: 0@0}.
		{aFileList morphicFileListPane. midLine @ 0 corner: 1@fileListBottom. 
					0@fileListTopOffset corner: 0@0}.
		{aFileList morphicFileContentsPane. 0@fileListBottom corner: 1@1. nil}.
	}.
	aFileList postOpen.
	^ window 