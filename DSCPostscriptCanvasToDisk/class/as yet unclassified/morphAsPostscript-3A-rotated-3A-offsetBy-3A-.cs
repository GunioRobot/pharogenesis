morphAsPostscript: aMorph rotated: rotateFlag offsetBy: offset

	| newFileName stream |

	^[
		(self new morphAsPostscript: aMorph rotated: rotateFlag offsetBy: offset) close
	]
		on: PickAFileToWriteNotification
		do: [ :ex |
			newFileName _ FillInTheBlank
				request: 'Name of file to write:' 
				initialAnswer: 'xxx',Time millisecondClockValue printString,'.eps'. 
			newFileName isEmptyOrNil ifFalse: [
				stream _ FileStream fileNamed: newFileName.
				stream ifNotNil: [ex resume: stream].
			].
		].

