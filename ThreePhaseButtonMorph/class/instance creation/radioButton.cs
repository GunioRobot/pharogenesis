radioButton
	"Answer a button pre-initialized with radiobutton images."
	| f |
	^self new
		onImage: (f _ ScriptingSystem formAtKey: 'RadioButtonOn');
		pressedImage: (ScriptingSystem formAtKey: 'RadioButtonPressed');
		offImage: (ScriptingSystem formAtKey: 'RadioButtonOff');
		extent: f extent + (2@0);
		yourself
