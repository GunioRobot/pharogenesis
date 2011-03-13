addEntry
	"Add a new Entry to the inspected object"

	| newKey |
	newKey _ FillInTheBlank request:
'Enter new key, then type RETURN.
(Expression will be evaluated for value.)'.
	newKey _ Compiler evaluate: newKey.
	model addEntry: newKey