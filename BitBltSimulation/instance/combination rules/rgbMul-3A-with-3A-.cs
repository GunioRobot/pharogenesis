rgbMul: sourceWord with: destinationWord
	self inline: false.
	destDepth < 16 ifTrue:
		["Mul each pixel separately"
		^ self partitionedMul: sourceWord with: destinationWord
						nBits: destDepth nPartitions: destPPW].
	destDepth = 16 ifTrue:
		["Mul RGB components of each pixel separately"
		^ (self partitionedMul: sourceWord with: destinationWord
						nBits: 5 nPartitions: 3)
		+ ((self partitionedMul: sourceWord>>16 with: destinationWord>>16
						nBits: 5 nPartitions: 3) << 16)]
	ifFalse:
		["Mul RGB components of the pixel separately"
		^ self partitionedMul: sourceWord with: destinationWord
						nBits: 8 nPartitions: 3]

"	| scanner |
	Display repaintMorphicDisplay.
	scanner _ DisplayScanner quickPrintOn: Display.
	MessageTally time: [0 to: 760 by: 4 do:  [:y |scanner drawString: 'qwrepoiuasfd=)(/&()=#!¡lkjzxv.,mn124+09857907QROIYTOAFDJZXNBNB,M-.,Mqwrepoiuasfd=)(/&()=#!¡lkjzxv.,mn124+09857907QROIYTOAFDJZXNBNB,M-.,M1234124356785678' at: 0@y]]. "