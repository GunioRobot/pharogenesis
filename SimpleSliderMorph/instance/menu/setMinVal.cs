setMinVal

	| newMinVal |
	newMinVal _ FillInTheBlank
		request: 'Minimum value?'
		initialAnswer: minVal printString.
	newMinVal isEmpty ifFalse: [
		minVal _ newMinVal asNumber.
		maxVal _ maxVal max: minVal].
