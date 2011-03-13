openProjectFromFile
	"Reconstitute a Morph from the selected file, presumed to be represent
	a Morph saved via the SmartRefStream mechanism, and open it in an
	appropriate Morphic world."

	fileName ifNil: [^self].
	Project canWeLoadAProjectNow ifFalse: [^ self].
	ProjectLoading 
		openFromDirectory: directory 
		andFileName: fileName
