ellipticalButtonWithText: aStringOrText

	| m prop |

	m _ EllipseMorph new.
	prop _ m ensuredButtonProperties.
	prop
		target: #(1 2 3);
		actionSelector: #inspect;
		actWhen: #mouseUp;
		addTextToButton: aStringOrText;
		wantsRolloverIndicator: true.
	^m