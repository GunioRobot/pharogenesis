unescapePercents
	"change each %XY substring to the character with ASCII value XY in hex.  This is the opposite of #encodeForHTTP"
	| ans c asciiVal pos oldPos specialChars |
	ans _ WriteStream on: String new.
	oldPos _ 1.
	specialChars _ '+%' asCharacterSet.

	[pos _ self indexOfAnyOf: specialChars startingAt: oldPos. pos > 0]
	whileTrue: [
		ans nextPutAll: (self copyFrom: oldPos to: pos - 1).
		c _ self at: pos.
		c = $+ ifTrue: [ans nextPut: $ ] ifFalse: [
			(c = $% and: [pos + 2 <= self size]) ifTrue: [
				asciiVal _ (self at: pos+1) asUppercase digitValue * 16 +
					(self at: pos+2) asUppercase digitValue.
				pos _ pos + 2.
				ans nextPut: (Character value: asciiVal)]
			ifFalse: [ans nextPut: c]].
		oldPos _ pos+1].
	ans nextPutAll: (self copyFrom: oldPos to: self size).
	^ ans contents