selectTranslationFileName
	"answer a file with a translation"
	| file |
	file := (StandardFileMenu oldFileMenu: FileDirectory default withPattern: '*.translation')
				startUpWithCaption: 'Select the file...' translated.
	^ file isNil
		ifFalse: [file directory fullNameFor: file name]