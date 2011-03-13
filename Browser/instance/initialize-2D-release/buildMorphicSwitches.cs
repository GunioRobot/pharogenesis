buildMorphicSwitches

	| instanceSwitch divider1 divider2 commentSwitch classSwitch row aColor |

	instanceSwitch _ PluggableButtonMorph
		on: self
		getState: #instanceMessagesIndicated
		action: #indicateInstanceMessages.
	instanceSwitch
		label: 'instance';
		askBeforeChanging: true;
		borderWidth: 0.
	commentSwitch _ PluggableButtonMorph
		on: self
		getState: #classCommentIndicated
		action: #plusButtonHit.
	commentSwitch
		label: '?' asText allBold;
		askBeforeChanging: true;
		setBalloonText: 'class comment';
		borderWidth: 0.
	classSwitch _ PluggableButtonMorph
		on: self
		getState: #classMessagesIndicated
		action: #indicateClassMessages.
	classSwitch
		label: 'class';
		askBeforeChanging: true;
		borderWidth: 0.
	divider1 := SubpaneDividerMorph vertical.
	divider2 := SubpaneDividerMorph vertical.
	row _ AlignmentMorph newRow
		hResizing: #spaceFill;
		vResizing: #spaceFill;
		layoutInset: 0;
		borderWidth: 0;
		addMorphBack: instanceSwitch;
		addMorphBack: divider1;
		addMorphBack: commentSwitch;
		addMorphBack: divider2;
		addMorphBack: classSwitch.

	aColor _ Color colorFrom: self defaultBackgroundColor.
	{instanceSwitch. commentSwitch. classSwitch} do: [:m | 
		m 
			color: aColor;
			onColor: aColor darker offColor: aColor;
			hResizing: #spaceFill;
			vResizing: #spaceFill.
	].

	^ row
