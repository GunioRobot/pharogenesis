open
	"Open a view of an instance of me on the default directory."
	"FileList open"
	| dir aFileList topView volListView templateView fileListView fileContentsView |
	World ifNotNil: [^ self openAsMorph].

	dir _ FileDirectory default.
	aFileList _ self new directory: dir.
	topView _ StandardSystemView new.
	topView
		model: aFileList;
		label: dir pathName;
		minimumSize: 200@200.
	topView borderWidth: 1.

	volListView _ PluggableListView on: aFileList
		list: #volumeList
		selected: #volumeListIndex
		changeSelected: #volumeListIndex:
		menu: #volumeMenu:.
	volListView autoDeselect: false.
	volListView window: (0@0 extent: 80@45).
	topView addSubView: volListView.

	templateView _ PluggableTextView on: aFileList
		text: #pattern
		accept: #pattern:.
	templateView askBeforeDiscardingEdits: false.
	templateView window: (0@0 extent: 80@15).
	topView addSubView: templateView below: volListView.

	fileListView _ PluggableListView on: aFileList
		list: #fileList
		selected: #fileListIndex
		changeSelected: #fileListIndex:
		menu: #fileListMenu:.
	fileListView window: (0@0 extent: 120@60).
	topView addSubView: fileListView toRightOf: volListView.

	fileContentsView _ PluggableTextView on: aFileList
		text: #contents accept: #put:
		readSelection: #contentsSelection menu: #fileContentsMenu:shifted:.
	fileContentsView window: (0@0 extent: 200@140).
	topView addSubView: fileContentsView below: templateView.

	topView controller open.
