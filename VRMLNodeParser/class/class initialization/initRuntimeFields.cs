initRuntimeFields
	"VRMLNodeParser initialize"
	VRMLRuntimeFieldTypes := Dictionary new.
	VRMLFieldTypes associationsDo:[:assoc|
		VRMLRuntimeFieldTypes at: assoc key put: assoc value.
	].
	VRMLRuntimeFieldTypes
		at: 'fieldType' put: #readScriptField:;
		at: 'eventType' put: #readScriptEvent:;
		yourself.