saveAsNewVersion
	"Save the image/changes using the next available version number."

	"Smalltalk saveAsNewVersion"
	| newName changesName aName anIndex |
	self deprecated: 'Use SmalltalkImage current saveAsNewVersion'.
	aName _ FileDirectory baseNameFor: (FileDirectory default localNameFor: SmalltalkImage current imageName).
	anIndex _ aName lastIndexOf: FileDirectory dot asCharacter ifAbsent: [nil].
	(anIndex notNil and: [(aName copyFrom: anIndex + 1 to: aName size) isAllDigits])
		ifTrue:
			[aName _ aName copyFrom: 1 to: anIndex - 1].

	newName _ FileDirectory default nextNameFor: aName extension: FileDirectory imageSuffix.
	changesName _ SmalltalkImage current fullNameForChangesNamed: newName.

	"Check to see if there is a .changes file that would cause a problem if we saved a new .image file with the new version number"
	(FileDirectory default includesKey: changesName)
		ifTrue:
			[^ self inform:
'There is already .changes file of the desired name,
', newName, '
curiously already present, even though there is
no corresponding .image file.   Please remedy
manually and then repeat your request.'].

	(SourceFiles at: 2) ifNotNil:
		[SmalltalkImage current closeSourceFiles; "so copying the changes file will always work"
			saveChangesInFileNamed: (SmalltalkImage current fullNameForChangesNamed: newName)].
	SmalltalkImage current saveImageInFileNamed: (SmalltalkImage current fullNameForImageNamed: newName)


