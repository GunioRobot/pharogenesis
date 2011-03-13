morphicViewImageViewer

	| dir aFileList window midLine fixedSize |

	dir _ FileDirectory default.
	aFileList _ self new directory: dir.
	aFileList optionalButtonSpecs: aFileList specsForImageViewer.
	aFileList fileSelectionBlock: [ :entry :myPattern |
		entry isDirectory ifTrue: [
			false
		] ifFalse: [
			#('bmp' 'gif' 'jpg' 'form' 'png') includes: 
					 (FileDirectory extensionFor: entry name asLowercase)
		]
	] fixTemps.
	window _ (SystemWindow labelled: dir pathName) model: aFileList.

	fixedSize _ 25.
	midLine _ 0.4.
	self addFullPanesTo: window from: {
		{aFileList optionalButtonRow. 0 @ 0 corner: 1 @ 0.
				0@0 corner: 0@fixedSize}.
		{aFileList morphicDirectoryTreePane. 0@0 corner: midLine@1.
				0@fixedSize corner: 0@0}.
		{aFileList morphicFileListPane. midLine @ 0 corner: 1@1.
				0@fixedSize corner: 0@0}.
	}.
	aFileList postOpen.
	^ window 