readFormsFromFileNamed: aFileName andStoreIntoGlobal: globalName
	"Read the a FormDictionary in from a designated file on disk and save it in the designated global"

	| aReferenceStream |
	aReferenceStream := ReferenceStream fileNamed: aFileName.
	Smalltalk at: globalName put: aReferenceStream next.
	aReferenceStream close

	"ScriptingSystem readFormsFromFileNamed: 'SystemFormsFromFwdF.forms' andStoreIntoGlobal: #FormsTemp"

	"ScriptingSystem saveForm:  (FormsTemp at: #StackElementDesignationHelp) atKey: #StackElementDesignationHelp"