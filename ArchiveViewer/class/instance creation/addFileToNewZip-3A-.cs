addFileToNewZip: fullName

	"Add the currently selected file to a new zip"
	| zip |
	zip := (ZipArchive new) 
			addFile: fullName 
			as: (FileDirectory localNameFor: fullName); yourself.
	(self open) archive: zip
