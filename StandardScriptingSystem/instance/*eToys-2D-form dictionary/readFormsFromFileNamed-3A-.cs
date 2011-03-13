readFormsFromFileNamed: aFileName
	"Read the entire FormDictionary in from a designated file on disk"

	| aReferenceStream |
	aReferenceStream := ReferenceStream fileNamed: aFileName.
	FormDictionary := aReferenceStream next.
	aReferenceStream close

	"ScriptingSystem readFormsFromFileNamed: 'EToyForms22Apr'"