storeBits:startBit to:stopBit on:aStream
	self do: [:word | 
		startBit to:stopBit by:-4 do:[:shift |		
				aStream print:((word >>shift) bitAnd:15) asHexDigit.
		]
	].