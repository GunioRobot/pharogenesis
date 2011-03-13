collectionFromFileNamed: fileName
	"Read the file.  It is an Array of StrikeFonts.  File format is the ReferenceStream version 2 format.  For any fonts with new names, add them to DefaultTextStyle.fontArray.  
	To write out fonts: (TextStyle default fontArray saveOnFile2).
	To read: (TextStyle default collectionFromFileNamed: 'new fonts')
*** Do not remove this method *** 8/19/96 tk"

	| ff this names |
	ff _ ReferenceStream fileNamed: fileName.
	[this _ ff next.
		this class == SmallInteger ifTrue: ["version number"].
		this class == Array ifTrue:
			[(this at: 1) = 'class structure' ifTrue:
				["Verify the shapes of all the classes"
				(Smalltalk incomingObjectsClass acceptStructures: this) ifFalse:
					[^ ff close]]].	"An error occurred"
		this class == Array ifTrue:
			[names _ self fontNames.
			this do: [:each | each class == StrikeFont ifTrue:
				[(names includes: each name) ifFalse:
					[fontArray _ fontArray copyWith: each]]]].
		ff atEnd]  whileFalse.		 
	ff close.