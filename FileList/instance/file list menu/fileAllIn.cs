fileAllIn
	"File in all of the currently selected file, if any."

	| ff |
	listIndex = 0 ifTrue: [^ self].
	ff _ directory oldFileNamed: self fullName.
	(self fileNameSuffix sameAs: 'html') ifTrue: [ff _ ff asHtml].
	ff fileIn.
