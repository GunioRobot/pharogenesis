checkBox
	"Answer a button pre-initialized with checkbox images."
	| f |
	^self new
		onImage: (f := ScriptingSystem formAtKey: 'CheckBoxOn');
		pressedImage: (ScriptingSystem formAtKey: 'CheckBoxPressed');
		offImage: (ScriptingSystem formAtKey: 'CheckBoxOff');
		extent: f extent + (2@0);
		yourself
