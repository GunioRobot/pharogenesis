readFormsFromFileNamed: aFileName
	"Read the entire FormDictionary in from a designated file on disk"

	| aReferenceStream |
	aReferenceStream _ ReferenceStream fileNamed: aFileName.
	FormDictionary _ aReferenceStream next.
	aReferenceStream close

	"ScriptingSystem readFormsFromFileNamed: 'EToyForms22Apr'"