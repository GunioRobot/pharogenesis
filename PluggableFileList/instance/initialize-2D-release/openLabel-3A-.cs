openLabel: aString
	"Open a view of an instance of me."
	"StandardFileDialog new open"
	| topView volListView templateView fileListView fileStringView leftButtonView middleButtonView rightButtonView |
	
	self directory: directory.
	topView _ (PluggableFileListView new)
		model: self.

	volListView _ PluggableListView on: self
		list: #volumeList
		selected: #volumeListIndex
		changeSelected: #volumeListIndex:
		menu: #volumeMenu:.
	volListView autoDeselect: false.
	volListView window: (0@0 extent: 80@45).
	topView addSubView: volListView.

	templateView _ PluggableTextView on: self
		text: #pattern
		accept: #pattern:.
	templateView askBeforeDiscardingEdits: false.
	templateView window: (0@0 extent: 80@15).
	topView addSubView: templateView below: volListView.

	fileListView _ PluggableListView on: self
		list: #fileList
		selected: #fileListIndex
		changeSelected: #fileListIndex:
		menu: #fileListMenu:.
	fileListView window: (0@0 extent: 120@60).

	topView addSubView: fileListView toRightOf: volListView.

	fileListView controller terminateDuringSelect: true.  "Pane to left may change under scrollbar"

	"fileStringView _ PluggableTextView on: self
		text: #fileString
		accept: #fileString:.
	fileStringView askBeforeDiscardingEdits: false.
	fileStringView window: (0@0 extent: 200@15).
	topView addSubView: fileStringView below: templateView."
	fileStringView _ templateView.


	leftButtonView _ PluggableButtonView 
		on: self
		getState: nil
		action: #leftButtonPressed.
	leftButtonView
		label: 'Cancel';
		backgroundColor: Color red;
		borderWidth: 3;
		window: (0@0 extent: 50@15).

	middleButtonView _ PluggableButtonView
		on: self
		getState: nil
		action: nil.
	middleButtonView
		label: prompt;
		window: (0@0 extent: 100@15);
		borderWidth: 1;
		controller: NoController new.

	rightButtonView _ PluggableButtonView
		on: self
		getState: nil
		action: #rightButtonPressed.
	rightButtonView
		label: 'Accept';
		backgroundColor: (self canAccept ifTrue: [Color green] ifFalse: [Color lightYellow]);
		borderWidth: (self canAccept ifTrue: [3] ifFalse: [1]);
		window: (0@0 extent: 50@15).
	self canAccept ifFalse: [rightButtonView controller: NoController new].

	topView acceptButtonView: rightButtonView.

	topView
		addSubView: leftButtonView below: fileStringView;
		addSubView: middleButtonView toRightOf: leftButtonView;
		addSubView: rightButtonView toRightOf: middleButtonView.

	self changed: #getSelectionSel.
	topView doModalDialog.
	
	^self result
