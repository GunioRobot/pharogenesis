readIntegerLineFrom: aStream
	"Read a positive integer from the given stream. Answer zero if there are no digits. Consume the stream through the next carriage return."

	| digit value |
	value _ 0.
	[aStream atEnd] whileFalse: 
		[digit _ aStream next digitValue.
		 ((digit >= 0) & (digit <= 9))
			ifTrue: 
				[value _ (value * 10) + digit]
			ifFalse:
				[(digit == Character cr digitValue) ifFalse:
					[self skipRestOfLine: aStream].
				 ^value]].
	^value