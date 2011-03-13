component: aComponent pinSpec: spec
	component _ aComponent.
	pinSpec _ spec.
	pinSpec isInput ifTrue: [pinForm _ InputPinForm].
	pinSpec isOutput ifTrue: [pinForm _ OutputPinForm].
	pinSpec isInputOutput ifTrue: [pinForm _ IoPinForm].
	self image: pinForm