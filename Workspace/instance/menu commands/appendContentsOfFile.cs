appendContentsOfFile
	"Prompt for a file, and if one is obtained, append its contents to the contents of the receiver.   Caution: as currently implemented this abandons any custom style information previously in the workspace.  Someone should fix this.  Also, for best results you should accept the contents of the workspace before requesting this."

	| aFileStream |
	(aFileStream _ FileList2 modalFileSelector) ifNil: [^ self].
	contents _ (contents ifNil: ['']) asString, aFileStream contentsOfEntireFile.
	aFileStream close.
	self changed: #contents