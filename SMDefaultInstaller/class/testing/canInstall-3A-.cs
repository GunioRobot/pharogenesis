canInstall: aPackage
	"Answer if this class can install/upgrade the package.
	This installer handles .st, .cs, .mst, .mcs (Squeak 3.9+)
	with or without .gz suffix."

	| fileName |
	fileName := aPackage downloadFileName.
	fileName ifNil: [^false].
	fileName := fileName asLowercase.
	^self sourceFileSuffixes anySatisfy: [:each | 
			(fileName endsWith: (FileDirectory dot, each)) or: [
				fileName endsWith: (FileDirectory dot, each, '.gz')]]