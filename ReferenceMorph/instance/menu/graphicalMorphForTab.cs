graphicalMorphForTab
	| formToUse |
	formToUse _ self valueOfProperty: #priorGraphic ifAbsent: [ScriptingSystem formAtKey: 'squeakyMouse'].
	^ SketchMorph withForm: formToUse