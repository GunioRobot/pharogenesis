update: actionRow in: window fileTypeRow: fileTypeRow morphUp: morph

	| fileTypeInfo info2 buttons textColor1 fileSuffixes fileActions aFileList fileTypeString |

	(morph valueOfProperty: #enabled) ifFalse: [^self].
	fileTypeRow submorphsDo: [ :sub |
		sub color: (
			sub == morph 
				ifTrue: [Color white] 
				ifFalse: [(sub valueOfProperty: #enabled) 
							ifTrue: [Color transparent] ifFalse: [Color gray]]
		).
	].
	fileTypeString _ morph valueOfProperty: #buttonText.

	aFileList _ window valueOfProperty: #FileList.
	textColor1 _ Color r: 0.742 g: 0.839 b: 1.0.
	actionRow removeAllMorphs.
	fileTypeInfo _ self endingSpecs.
	info2 _ fileTypeInfo detect: [ :each | each first = fileTypeString] ifNone: [self error: 'bad fileTypeString' ].
	fileSuffixes _ info2 second.
	fileActions _ info2 third.
	buttons _ fileActions collect: [ :each | aFileList blueButtonForService: each textColor: textColor1 inWindow: window ].
	buttons addLast: (self blueButtonText: 'Cancel' textColor: textColor1 inWindow: window balloonText: 'Cancel this search' translated selector: #cancelHit recipient: aFileList).
	buttons do: [ :each | actionRow addMorphBack: each].
	window fullBounds.
	buttons do: [ :each |
		each fillWithRamp: self blueRamp2 oriented: (0.75 @ 0).
	].
	aFileList fileSelectionBlock: (
		self selectionBlockForSuffixes: (fileSuffixes collect: [ :each | '*.',each])
	).
	aFileList updateFileList.

