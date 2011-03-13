openAsMorph     "FileList openAsMorph openInMVC"
	"Open a morphic view of a FileList on the default directory."
	| dir aFileList window |
	dir _ FileDirectory default.
	aFileList _ self new directory: dir.
	window _ (SystemWindow labelled: dir pathName) model: aFileList.

	window addMorph: ((PluggableListMorph on: aFileList list: #volumeList selected: #volumeListIndex
				changeSelected: #volumeListIndex:) autoDeselect: false)
		frame: (0@0 corner: 0.3@0.2).
	window addMorph: (PluggableTextMorph on: aFileList text: #pattern accept: #pattern:)
		frame: (0@0.2 corner: 0.3@0.3).
	window addMorph: (PluggableListMorph on: aFileList list: #fileList selected: #fileListIndex
				changeSelected: #fileListIndex: menu: #fileListMenu:)
		frame: (0.3@0 corner: 1@0.3).
	window addMorph: (PluggableTextMorph on: aFileList text: #contents accept: #put:
			readSelection: #contentsSelection menu: #fileContentsMenu:shifted:)
		frame: (0@0.3 corner: 1@1).
	^ window