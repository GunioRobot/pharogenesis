canInstall: aPackage
	"Answer if this class can install the package.
	We handle .translation files optionally compressed."

	| fileName |
	fileName _ aPackage downloadFileName.
	fileName ifNil: [^false].
	fileName _ fileName asLowercase.
	^(fileName endsWith: '.translation') or: [
		(fileName endsWith: '.tra') or: [
			(fileName endsWith: '.tra.gz') or: [
				fileName endsWith: '.translation.gz']]]