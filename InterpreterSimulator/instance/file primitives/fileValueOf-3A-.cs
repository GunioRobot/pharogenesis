fileValueOf: integerPointer
	"Convert the (integer) fileID to the actual fileStream it uses"
	self success: (self isIntegerObject: integerPointer).
	successFlag
		ifTrue: [^ filesOpen at: (self integerValueOf: integerPointer)]
		ifFalse: [^ nil]