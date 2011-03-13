nextUnsignedIntegerBase: aRadix ifFail: errorBlock
	"Form an unsigned integer with incoming digits from sourceStream.
	Count the number of digits and the lastNonZero digit and store int in instVar"
	
	| value digit |
	value := 0.
	nDigits := 0.
	lastNonZero := 0.
	aRadix <= 10
		ifTrue: ["Avoid using digitValue which is awfully slow"
			[sourceStream atEnd
				or: [digit := sourceStream next charCode - 48.
					(digit < 0
							or: [digit >= aRadix])
						and: [sourceStream skip: -1.
							true]]]
				whileFalse: [nDigits := nDigits + 1.
					digit isZero
						ifFalse: [lastNonZero := nDigits].
					value := value * aRadix + digit]]
		ifFalse: [
			[sourceStream atEnd
				or: [digit := sourceStream next digitValue.
					(digit < 0
							or: [digit >= aRadix])
						and: [sourceStream skip: -1.
							true]]]
				whileFalse: [nDigits := nDigits + 1.
					digit isZero
						ifFalse: [lastNonZero := nDigits].
					value := value * aRadix + digit]].
	nDigits = 0
		ifTrue: [errorBlock value].
	^value