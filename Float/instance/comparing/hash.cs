hash
	"Hash is reimplemented because = is implemented.
	 Both words of the double float are used; 8 bits are
	 removed from each end to clear most of the exponent
	 regardless of the byte ordering. (Three bitAnd:s are
	 utilized to assure the intermediate results do not
	 become a large integer.) Slower than the original
	 version in the ratios 12:5 to 2:1 depending on values.
	 Answers the same result on Big Endian and Small Endian
	 IEEE machines.(DNS, 11 May, 1997) "

	^ (
		(
			((self basicAt: 1) bitAnd: 16r00FFFF00) +
			((self basicAt: 2) bitAnd: 16r00FFFF00)
		) bitAnd: 16r00FFFF00
	  ) >> 8
