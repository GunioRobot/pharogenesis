morphAsPostscript: aMorph rotated: rotateFlag offsetBy: offset specs: specsOrNil

	| newFileName stream |

	^[
		(self new morphAsPostscript: aMorph rotated: rotateFlag offsetBy: offset) close
	]
		on: PickAFileToWriteNotification
		do: [ :ex |
			newFileName _ FillInTheBlank
				request: 'Name of file to write:' translated
				initialAnswer: 'xxx',Time millisecondClockValue printString, self defaultExtension. 
			newFileName isEmptyOrNil ifFalse: [
				stream _ FileStream fileNamed: newFileName.
				stream ifNotNil: [ex resume: stream].
			].
		].

