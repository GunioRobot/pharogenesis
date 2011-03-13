recordButton: buttonId character: characterId state: state layer: layer matrix: matrix colorTransform: cxForm
	| button children shape |
	button := buttons at: buttonId ifAbsent:[^self error: 'button missing'].
	button id: buttonId.
	shape := self oldMorphFromShape: characterId.
	shape isNil ifTrue:[^nil].
	children := shape submorphs collect:[:m| m veryDeepCopy].
	shape := FlashMorph withAll: children.
	shape lockChildren.
	shape depth: layer.
	shape transform: matrix.
	shape colorTransform: cxForm.
	(state anyMask: 1) ifTrue:[
		button defaultLook: shape.
	].
	(state anyMask: 2) ifTrue:[
		button overLook: shape.
	].
	(state anyMask: 4) ifTrue:[
		button pressLook: shape.
	].
	(state anyMask: 8) ifTrue:[
		button sensitiveLook: shape.
	].
	button lockChildren.