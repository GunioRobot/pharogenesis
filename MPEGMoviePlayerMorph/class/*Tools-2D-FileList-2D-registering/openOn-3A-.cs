openOn: fileNameString 
	"open a new instance of the receiver on a file named 
	fileNameString "
	| wrapper |
	wrapper := self new.
	wrapper moviePlayer openFileNamed: fileNameString.
	^ wrapper