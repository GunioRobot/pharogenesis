initialize
	"VRMLStream initialize"
	NonFirstChars := Set new: 100.
	NonFirstChars 
		addAll: (16r30 to: 16r39);
		addAll: (16r0 to: 16r20);
		addAll: #(16r22 16r23 16r27 16r2B 16r2C 16r2D 16r2E 16r5B 16r5C 16r5D 16r7B 16r7D 16r7F).
	NonRestChars := Set new: 100.
	NonRestChars
		addAll: (16r0 to: 16r20);
		addAll: #(16r22 16r23 16r27 16r2C 16r2E 16r5B 16r5C 16r5D 16r7B 16r7D 16r7F).

	SeparatorChars := Set new: 10.
	SeparatorChars addAll: #(16r0D 16r0A 16r20 16r09 16r2C 16r23).

	DigitValues _ Array new: 256.
	DigitValues atAllPut: -1.
	0 to: $9 asciiValue do:[:i|
		DigitValues at: i+1 put: i - $0 asciiValue].
	$A asciiValue to: $Z asciiValue do:[:i|
		DigitValues at: i+1 put: i - $A asciiValue + 10].
	0 to: 255 do:[:i|
		(DigitValues at: i+1) = (Character value: i) digitValue
			ifFalse:[^self error:'Digit value initialization failed'].
	].