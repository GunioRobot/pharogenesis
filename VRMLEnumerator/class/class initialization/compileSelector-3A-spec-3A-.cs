compileSelector: selector spec: nodeSpec

	| isComposite source |
	isComposite := nodeSpec containsAttribute: 'children' ofType: 'MFNode'.
	source := String streamContents:[:s|
		s nextPutAll: selector.
		s nextPutAll:' aVRMLNode'.
		s crtab; nextPutAll:'"This method was automatically generated"'.
		s crtab; nextPutAll:'^self'.
		('*Light*' match: nodeSpec name ) ifTrue:[
			s nextPutAll:' doLight: aVRMLNode'.
		] ifFalse:[
		('*Interpolator*' match: nodeSpec name) ifTrue:[
			s nextPutAll:' doInterpolator: aVRMLNode'.
		] ifFalse:[
		('*Sensor*' match: nodeSpec name) ifTrue:[
			s nextPutAll:' doSensor: aVRMLNode'.
		] ifFalse:[
			isComposite ifTrue:[s nextPutAll:' doChildrenOf: aVRMLNode']]]].
		].
	self compile: source classified: 'enumerating nodes'.
