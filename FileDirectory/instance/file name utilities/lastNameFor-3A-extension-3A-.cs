lastNameFor: baseFileName extension: extension
	"Assumes a file name includes a version number encoded as '.' followed by digits 
	preceding the file extension.  Increment the version number and answer the new file name.
	If a version number is not found, set the version to 1 and answer a new file name"

	| files splits |

	files _ self fileNamesMatching: (baseFileName,'*', self class dot, extension).
	splits _ files 
			collect: [:file | self splitNameVersionExtensionFor: file]
			thenSelect: [:split | (split at: 1) = baseFileName].
	splits _ splits asSortedCollection: [:a :b | (a at: 2) < (b at: 2)].
	^splits isEmpty 
			ifTrue: [nil]
			ifFalse: [(baseFileName, '.', (splits last at: 2) asString, self class dot, extension) asFileName]