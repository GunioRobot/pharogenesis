renameEntry
	| newKey aKey value |

	value _ object at: (keyArray at: selectionIndex - self numberOfFixedFields).
	newKey _ FillInTheBlank request: 
'Enter new key, then type RETURN.
(Expression will be evaluated for value.)
Examples:  #Fred    ''a string''   3+4'
		 initialAnswer: (keyArray at: selectionIndex - self numberOfFixedFields) printString.
	aKey _ Compiler evaluate: newKey.
	object removeKey: (keyArray at: selectionIndex - self numberOfFixedFields).
	object at: aKey put: value.
	self calculateKeyArray.
	selectionIndex _ self numberOfFixedFields + (keyArray indexOf: aKey).
	self changed: #selectionIndex.
	self changed: #inspectObject.
	self changed: #fieldList.
	self update