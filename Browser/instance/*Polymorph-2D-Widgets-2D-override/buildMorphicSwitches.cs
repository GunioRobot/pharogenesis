buildMorphicSwitches

	| instanceSwitch commentSwitch classSwitch row |

	instanceSwitch := PluggableButtonMorph
		on: self
		getState: #instanceMessagesIndicated
		action: #indicateInstanceMessages.
	instanceSwitch
		label: 'instance';
		askBeforeChanging: true;
		borderWidth: 1;
		borderColor: Color gray.
	commentSwitch := PluggableButtonMorph
		on: self
		getState: #classCommentIndicated
		action: #plusButtonHit.
		
	commentSwitch
		label: '?' asText allBold;
		askBeforeChanging: true;
		setBalloonText: 'class comment';
		borderWidth: 1;
		borderColor: Color gray.
	classSwitch := PluggableButtonMorph
		on: self
		getState: #classMessagesIndicated
		action: #indicateClassMessages.
	classSwitch
		label: 'class';
		askBeforeChanging: true;
		borderWidth: 1;
		borderColor: Color gray.
	row := AlignmentMorph newRow
		hResizing: #spaceFill;
		vResizing: #spaceFill;
		cellInset: 0;
		borderWidth: 0;
		layoutInset: 0;
		addMorphBack: instanceSwitch;
		addMorphBack: commentSwitch;
		addMorphBack: classSwitch.

	row color: Color white.
	{instanceSwitch. commentSwitch. classSwitch} do: [:m | 
		m 
			color: Color transparent;
			hResizing: #spaceFill;
			vResizing: #spaceFill.].
	^ row
