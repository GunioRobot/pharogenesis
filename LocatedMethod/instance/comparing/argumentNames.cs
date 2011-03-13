argumentNames
	"Return an array with the argument names of the method's selector"

	| keywords stream argumentNames argumentName delimiters |
	delimiters _ {Character space. Character cr}.
	keywords _ self selector keywords.
	stream _ self source readStream.
	argumentNames _ OrderedCollection new.
	keywords do: [ :each |
		stream match: each.
		[stream peekFor: Character space] whileTrue.
		argumentName _ ReadWriteStream on: String new.
		[(delimiters includes: stream peek) or: [stream peek isNil]]
			whileFalse: [argumentName nextPut: stream next].
		argumentName isEmpty ifFalse: [
			argumentNames add: argumentName contents withBlanksTrimmed]].
	^(argumentNames copyFrom: 1 to: self method numArgs) asArray