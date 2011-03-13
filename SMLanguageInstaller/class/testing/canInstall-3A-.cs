canInstall: aPackage
	"Answer if this class can install the package.
	We handle .translation files optionally compressed."

	| fileName |
	((Smalltalk includesKey: #Language)
		or: [Smalltalk includesKey: #NaturalLanguageTranslator]) ifFalse: [^false].
	fileName := aPackage downloadFileName.
	fileName ifNil: [^false].
	fileName := fileName asLowercase.
	^(fileName endsWith: '.translation') or: [
		(fileName endsWith: '.tra') or: [
			(fileName endsWith: '.tra.gz') or: [
				fileName endsWith: '.translation.gz']]]