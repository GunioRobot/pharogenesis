setMaxVal

	| newMaxVal |
	newMaxVal _ FillInTheBlank
		request: 'Maximum value?'
		initialAnswer: maxVal printString.
	newMaxVal isEmpty ifFalse: [
		maxVal _ newMaxVal asNumber.
		minVal _ minVal min: maxVal].
