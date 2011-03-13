absolutePathFor: path locationType: aSymbol
	"answer an absolute path from an absolute or relative path according to the location type aSymbol"

	aSymbol = #imageRelative
		 ifTrue:[^SmalltalkImage current imagePath, FileDirectory slash, path ].
	aSymbol = #vmRelative 
		ifTrue:[^SmalltalkImage current vmPath ", FileDirectory slash" , path].
	^path
	
	
	
			
	
	