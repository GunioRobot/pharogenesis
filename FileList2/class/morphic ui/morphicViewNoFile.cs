morphicViewNoFile

	| dir aFileList window midLine fixedSize |

	dir _ FileDirectory default.
	aFileList _ self new directory: dir.
	window _ (SystemWindow labelled: dir pathName) model: aFileList.

	fixedSize _ 25.
	midLine _ 0.4.
	self addFullPanesTo: window from: {
		{aFileList morphicPatternPane. 0@0 corner: 0.3@0. 0@0 corner: 0@fixedSize}.
		{aFileList optionalButtonRow. 0.3 @ 0 corner: 1@0. 0@0 corner: 0@fixedSize}.
		{aFileList morphicDirectoryTreePane. 0@0 corner: midLine@1. 0@fixedSize corner: 0@0}.
		{aFileList morphicFileListPane. midLine @ 0 corner: 1@1. 0@fixedSize corner: 0@0}.
	}.
	aFileList postOpen.
	^ window 