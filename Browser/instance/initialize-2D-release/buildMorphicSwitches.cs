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
	divider1 := BorderedSubpaneDividerMorph vertical.
	divider2 := BorderedSubpaneDividerMorph vertical.
	Preferences alternativeWindowLook ifTrue:[
		divider1 extent: 4@4; borderWidth: 2; borderRaised; color: Color transparent.
		divider2 extent: 4@4; borderWidth: 2; borderRaised; color: Color transparent.
	].
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
	row color: aColor duller.  "ensure matching button divider color. (see #paneColor)"
	Preferences alternativeWindowLook ifTrue:[aColor _ aColor muchLighter].
	{instanceSwitch. commentSwitch. classSwitch} do: [:m | 
		m 
			color: aColor;
			onColor: aColor twiceDarker offColor: aColor;
			hResizing: #spaceFill;
			vResizing: #spaceFill.
	].

	^ row
