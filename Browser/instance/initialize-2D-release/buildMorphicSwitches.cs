buildMorphicSwitches

	| instanceSwitch commentSwitch classSwitch row aColor |

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
		cellInset: 1;
		borderWidth: 0;
		addMorphBack: instanceSwitch;
		addMorphBack: commentSwitch;
		addMorphBack: classSwitch.

	aColor := Color white.
	row color: aColor muchLighter.
	{instanceSwitch. commentSwitch. classSwitch} do: [:m | 
		m 
			color: aColor;
			onColor: aColor darker darker offColor: aColor;
			hResizing: #spaceFill;
			vResizing: #spaceFill.].
	^ row
