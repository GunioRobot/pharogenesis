canInstall: aPackage
	"Answer if this class can install/upgrade the package.
	This installer handles .st, .cs, .st.gz and .cs.gz files."

	| fileName |
	fileName _ aPackage downloadFileName.
	fileName ifNil: [^false].
	fileName _ fileName asLowercase.
	^ FileStream sourceFileSuffixes anySatisfy: [:each | 
		(fileName endsWith: (FileDirectory dot, each)) or: [
			fileName endsWith: (FileDirectory dot, each, '.gz')].
	].
