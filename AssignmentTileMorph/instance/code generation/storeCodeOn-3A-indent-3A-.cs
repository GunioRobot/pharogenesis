storeCodeOn: aStream indent: tabCount

	aStream nextPutAll: ' assign', (assignmentSuffix copyWithout: $:), 'Getter: #'.
	aStream nextPutAll: (ScriptingSystem getterSelectorFor: assignmentRoot).
	aStream nextPutAll: ' setter: #'.
	aStream nextPutAll: (ScriptingSystem setterSelectorFor: assignmentRoot).
	aStream nextPutAll: ' amt: '.
