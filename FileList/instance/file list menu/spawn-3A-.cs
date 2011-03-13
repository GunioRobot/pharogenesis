spawn: code
	"Open a simple Edit window"
	listIndex = 0 ifTrue: [^ self].
	FileList openEditorOn: (directory readOnlyFileNamed: fileName)
				"read only just for initial look"
			editString: code