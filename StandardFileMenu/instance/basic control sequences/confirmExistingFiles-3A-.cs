confirmExistingFiles: aResult

	|choice|
	(aResult directory fileExists: aResult name) ifFalse: [^aResult].
	
	choice _ (PopUpMenu
		labels:
'overwrite that file
choose another name
cancel')
		startUpWithCaption: aResult name, '
already exists.'.

	choice = 1 ifTrue: [
		aResult directory 
			deleteFileNamed: aResult name
			ifAbsent: 
				[^self startUpWithCaption: 
'Can''t delete ', aResult name, '
Select another file'].
		^aResult].
	choice = 2 ifTrue: [^self startUpWithCaption: 'Select Another File'].
	^nil
 