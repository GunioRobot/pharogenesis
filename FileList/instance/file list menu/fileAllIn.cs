fileAllIn
	"File in all of the currently selected file, if any."
	"wod 5/24/1998: open the file read only."

	| fn ff |
	listIndex = 0 ifTrue: [^ self].
	ff _ directory readOnlyFileNamed: (fn _ self uncompressedFileName).
	((self getSuffix: fn) sameAs: 'html') ifTrue: [ff _ ff asHtml].
	ff fileIn