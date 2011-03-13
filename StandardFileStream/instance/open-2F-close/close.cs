close
	"Close the receiver."

	closed ifTrue: [^ self].
	self primClose: fileID.
	closed _ true.
