addEntry
	| newKey aKey |

	newKey _ FillInTheBlank request:
'Enter new key, then type RETURN.
(Expression will be evaluated for value.)
Examples:  #Fred    ''a string''   3+4'.
	aKey _ Compiler evaluate: newKey.
	object at: aKey put: nil.
	self calculateKeyArray.
	selectionIndex _ self numberOfFixedFields + (keyArray indexOf: aKey).
	self changed: #inspectObject.
	self changed: #selectionIndex.
	self changed: #fieldList.
	self update