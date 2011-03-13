storeCodeOn: aStream indent: tabCount
	"Generate code for an assignment statement.  The code generated looks presentable in the case of simple assignment, though the code generated for the increment/decrement/multiply cases is still the same old assignGetter... sort for now"

	assignmentSuffix = ':'
		ifTrue:   "Simple assignment, don't need existing value"
			[aStream nextPutAll: (ScriptingSystem setterSelectorFor: assignmentRoot).
			aStream space]
		ifFalse:  "Assignments that require that old values be retrieved"
			[aStream nextPutAll: ' assign', (assignmentSuffix copyWithout: $:), 'Getter: #'.
			aStream nextPutAll: (ScriptingSystem getterSelectorFor: assignmentRoot).
			aStream nextPutAll: ' setter: #'.
			aStream nextPutAll: (ScriptingSystem setterSelectorFor: assignmentRoot).
			aStream nextPutAll: ' amt: ']