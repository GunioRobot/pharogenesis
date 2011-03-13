absoluteOrRelativePathFor: absolutePath locationType: aSymbol
	"answer a relative path from an absolute path according to the location type aSymbol"
	| p |

	aSymbol = #absolute ifTrue:[^absolutePath].
	aSymbol = #imageRelative ifTrue:[p := SmalltalkImage current imagePath].
	aSymbol = #vmRelative ifTrue:[p := SmalltalkImage current vmPath].
	(p notNil and:[absolutePath asLowercase beginsWith: p asLowercase])
		ifTrue:[^absolutePath copyFrom: p size + 1 to: absolutePath size].
	^absolutePath
	
	
	
			
	
	