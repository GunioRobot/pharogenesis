openAsMorphLabel: aString inWorld: aWorld
	"Open a view of an instance of me."
	"PluggableFileList new openAsMorphLabel: 'foo' inWorld: World"
	| windowMorph volListMorph templateMorph fileListMorph leftButtonMorph middleButtonMorph rightButtonMorph |
	
	self directory: directory.
	windowMorph _ (SystemWindow labelled: aString) model: self.

	volListMorph _ PluggableListMorph on: self
		list: #volumeList
		selected: #volumeListIndex
		changeSelected: #volumeListIndex:
		menu: #volumeMenu:.
	volListMorph autoDeselect: false.
	windowMorph addMorph: volListMorph frame: (0@0 corner: 0.4@0.5625).

	templateMorph _ PluggableTextMorph on: self
		text: #pattern
		accept: #pattern:.
	templateMorph askBeforeDiscardingEdits: false.
	windowMorph addMorph: templateMorph frame: (0@0.5625 corner: 0.4@0.75).

	fileListMorph _ PluggableListMorph on: self
		list: #fileList
		selected: #fileListIndex
		changeSelected: #fileListIndex:
		menu: #fileListMenu:.

	windowMorph addMorph: fileListMorph frame: (0.4@0 corner: 1.0@0.75).

	leftButtonMorph _ PluggableButtonMorph 
		on: self
		getState: #leftButtonState
		action: #leftButtonPressed.
	leftButtonMorph
		label: 'Cancel';
		onColor: Color red offColor: Color red;
		feedbackColor: Color orange;
		borderWidth: 3.

	middleButtonMorph _ PluggableButtonMorph
		on: self
		getState: nil
		action: nil.
	middleButtonMorph
		label: prompt;
		onColor: Color lightYellow offColor: Color lightYellow;
		feedbackColor: Color lightYellow;
		borderWidth: 1.

	rightButtonMorph _ PluggableButtonMorph
		on: self
		getState: #rightButtonState
		action: #rightButtonPressed.
	rightButtonMorph
		label: 'Accept';
		onColor: Color green offColor: Color lightYellow;
		feedbackColor: Color black;
		borderWidth: (self canAccept ifTrue: [3] ifFalse: [1]).
	"self canAccept ifFalse: [rightButtonMorph controller: NoController new]."

	windowMorph
		addMorph: leftButtonMorph frame: (0@0.75 corner: 0.25@1.0);
		addMorph: middleButtonMorph frame: (0.25@0.75 corner: 0.75@1.0);
		addMorph: rightButtonMorph frame: (0.75@0.75 corner: 1.0@1.0).

	self changed: #getSelectionSel.

	windowMorph openInWorld
