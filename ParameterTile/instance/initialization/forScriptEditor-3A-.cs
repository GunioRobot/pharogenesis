forScriptEditor: aScriptEditor
	"Make the receiver be associated with the given script editor"

	scriptEditor _ aScriptEditor.
	self line1: aScriptEditor typeForParameter translated.