collectionFromFileNamed: fileName
	"Read the file.  It is an Array of StrikeFonts.  File format is the ReferenceStream format.  (Do not use SmartRefStream, it is too smart.  It only writes a DiskProxy!)   For any fonts with new names, add them to DefaultTextStyle.fontArray.  
	To write out fonts: 
		| ff | ff _ ReferenceStream fileNamed: 'new fonts'.
		ff nextPut: (TextStyle default fontArray).
		ff close.
	To read: (TextStyle default collectionFromFileNamed: 'new fonts')
*** Do not remove this method *** "

	| ff this names |
	ff _ ReferenceStream fileNamed: fileName.
	this _ ff nextAndClose.
		"Only works if file created by ReferenceStream, not SmartRefStream"
	this class == Array ifTrue:
			[names _ self fontNames.
			this do: [:each | each class == StrikeFont ifTrue:
				[(names includes: each name) ifFalse:
					[fontArray _ fontArray copyWith: each]]]].
