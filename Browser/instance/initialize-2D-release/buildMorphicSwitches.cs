buildMorphicSwitches

	| instanceSwitch commentSwitch classSwitch row aColor |

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
		action: #plusButtonHit.
	commentSwitch
		label: '?' asText allBold;
		askBeforeChanging: true;
		setBalloonText: 'class comment'.
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

	aColor _ Color colorFrom: self defaultBackgroundColor.
	row submorphs do:
		[:m | m color: aColor.
		m onColor: aColor darker offColor: aColor].

	^ row
