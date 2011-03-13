morphForModel: aModel
	| morph paneColor |
	morph _ aModel morph.
	paneColor _ browser defaultBackgroundColor.
	morph onColor: paneColor darker offColor: paneColor lighter.
	^ morph