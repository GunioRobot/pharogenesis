initScriptFields
	"VRMLNodeParser initialize"
	| |
	VRMLScriptFieldTypes := Dictionary new.
	VRMLFieldTypes associationsDo:[:assoc|
		VRMLScriptFieldTypes at: assoc key put: assoc value.
	].
	VRMLScriptFieldTypes
		at: 'fieldType' put: #parseScriptField:;
		at: 'eventType' put: #parseScriptEvent:;
		yourself.