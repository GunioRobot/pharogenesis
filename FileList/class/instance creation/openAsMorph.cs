openAsMorph
	"Open a morphic view of a FileList on the default directory."
	| dir aFileList window upperFraction offset |
	dir _ FileDirectory default.
	aFileList _ self new directory: dir.
	window _ (SystemWindow labelled: dir pathName)
				model: aFileList.
	upperFraction _ 0.3.
	offset _ 0.
	self
		addVolumesAndPatternPanesTo: window
		at: (0 @ 0 corner: 0.3 @ upperFraction)
		plus: offset
		forFileList: aFileList.
	self
		addButtonsAndFileListPanesTo: window
		at: (0.3 @ 0 corner: 1.0 @ upperFraction)
		plus: offset
		forFileList: aFileList.
	window
		addMorph: (PluggableTextMorph
				on: aFileList
				text: #contents
				accept: #put:
				readSelection: #contentsSelection
				menu: #fileContentsMenu:shifted:)
		frame: (0 @ 0.3 corner: 1 @ 1).
	^ window