fileHandle
	"Answer my file, or nil if the file is not open."

	file ifNil: [^ nil].
	file closed ifTrue: [^ nil].
	^ file
