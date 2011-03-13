buildMorphicSwitches

	| instanceSwitch commentSwitch classSwitch row |
	instanceSwitch _ PluggableButtonMorph
		on: self
		getState: #instanceMessagesIndicated
		action: #indicateInstanceMessages.
	instanceSwitch
		label: 'instance';
		askBeforeChanging: true.
	commentSwitch _ PluggableButtonMorph
		on: self
		getState: #classCommentIndicated
		action: #editComment.
	commentSwitch
		label: '?' asText allBold asParagraph;
		askBeforeChanging: true.
	classSwitch _ PluggableButtonMorph
		on: self
		getState: #classMessagesIndicated
		action: #indicateClassMessages.
	classSwitch
		label: 'class';
		askBeforeChanging: true.
	row _ AlignmentMorph newRow
		hResizing: #spaceFill;
		vResizing: #spaceFill;
		inset: 0;
		borderColor: Color transparent;
		addMorphBack: instanceSwitch;
		addMorphBack: commentSwitch;
		addMorphBack: classSwitch.
	^ row
