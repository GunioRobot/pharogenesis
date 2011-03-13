fileOutCategory: aString 
	"Create a file whose name is the name of the receiver with -.st- as the 
	extension, and file a description of the receiver's category aString onto it."

	| fileName fileStream |
	fileName _ (self name , '-' , aString , '.st') asFileName.
	fileStream _ FileStream newFileNamed: fileName.
	fileStream header; timeStamp.
	self fileOutCategory: aString
		on: fileStream
		moveSource: false
		toFile: 0.
	fileStream trailer; close