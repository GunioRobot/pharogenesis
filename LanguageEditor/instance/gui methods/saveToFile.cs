saveToFile
	"save the translator to a file"
	| fileName |
	fileName := FillInTheBlank request: 'file name' translated initialAnswer: translator localeID isoString , '.translation'.
	(fileName isNil
			or: [fileName isEmpty])
		ifTrue: [""
			self beep.
			^ self].
	""
Cursor wait
		showWhile: [
	self translator saveToFileNamed: fileName]