digitValue: char

	| value |
	value _ char charCode.
	value <= $9 asciiValue 
		ifTrue: [^value - $0 asciiValue].
	value >= $A asciiValue 
		ifTrue: [value <= $Z asciiValue ifTrue: [^value - $A asciiValue + 10]].

	value > (DecimalProperty size - 1) ifTrue: [^ -1].
	^ (DecimalProperty at: value+1)
