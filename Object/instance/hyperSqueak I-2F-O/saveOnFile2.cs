saveOnFile2
	"Ask the user for a filename and save myself on a ReferenceStream file.
	 Put out structure of non-HyperSqueak object.  8/19/96 tk
	 9/19/96 sw: adjustments for case where HyperSqueak is not present, though this code
		at present is not reached except from HyperSqueak code"

	| aFileName manager model aStream bytes sqSupport |

	aFileName _ self class name asFileName.	"do better?"
	aFileName _ FillInTheBlank request: 'File name?' initialAnswer: aFileName.
	aFileName size == 0 ifTrue: [^ self beep].

	sqSupport _ self hyperSqueakSupportClass.
	sqSupport == nil ifFalse:
		[sqSupport preReleaseFileOut: true].	"Force writing of sys objects"
	manager _ DataStream incomingObjectsClass new.
	manager install: model.
	aStream _ ReferenceStream newFileNamed: aFileName.
	aStream nextPut: ReferenceStream versionCode;
		nextPut: manager instVarInfo;
		nextPut: self.
	bytes _ aStream close.
	sqSupport == nil ifFalse:
		[sqSupport preReleaseFileOut: false].	"normal"

	Transcript cr; show: 'Successfully saved to ', aFileName, ' with length ', bytes printString.