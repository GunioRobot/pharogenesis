clipboardRead: sz Into: actualAddress At: zeroBaseIndex
	| str |
	str _ Clipboard clipboardText.
	1 to: sz do:
		[:i | self byteAt: actualAddress + zeroBaseIndex + i - 1 put: (str at: i) asciiValue]