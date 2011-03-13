saveToFile
	"save the translator to a file"
	| fileName |
	fileName := UIManager default request: 'file name' translated initialAnswer: translator localeID isoString , '.translation'.
	fileName isEmptyOrNil
		ifTrue: [""
			self beep.
			^ self].
	""
Cursor wait
		showWhile: [
	self translator saveToFileNamed: fileName]