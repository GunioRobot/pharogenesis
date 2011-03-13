openAsMorph
	"Open a morphic view of a FileList on the default directory."
	| dir aFileList window fileListTop |
	dir _ FileDirectory default.
	aFileList _ self new directory: dir.
	window _ (SystemWindow labelled: dir pathName) model: aFileList.

	window addMorph: ((PluggableListMorph on: aFileList list: #volumeList selected: #volumeListIndex
				changeSelected: #volumeListIndex: menu: #volumeMenu:) autoDeselect: false)
		frame: (0@0 corner: 0.3@0.2).
	window addMorph: (PluggableTextMorph on: aFileList text: #pattern accept: #pattern:)
		frame: (0@0.2 corner: 0.3@0.3).
	aFileList wantsOptionalButtons
		ifTrue:
			[window addMorph: aFileList optionalButtonRow frame: (0.3 @ 0 corner: 1 @ 0.08).
			fileListTop _ 0.08]
		ifFalse:
			[fileListTop _ 0].

	window addMorph: (PluggableListMorph on: aFileList list: #fileList selected: #fileListIndex
				changeSelected: #fileListIndex: menu: #fileListMenu:)
		frame: (0.3 @ fileListTop corner: 1@0.3).
	window addMorph: (PluggableTextMorph on: aFileList text: #contents accept: #put:
			readSelection: #contentsSelection menu: #fileContentsMenu:shifted:)
		frame: (0@0.3 corner: 1@1).
	^ window