store15To24HexBitsOn:aStream
	bits do: [:word | 
		#( 31 26 21 15 10 5 )  do:[:startBit |		
				aStream print:((word >>(startBit-4)) bitAnd:15) asHexDigit.
				aStream print:((word >>(startBit+1)) bitAnd:8) asHexDigit.
		]
	].