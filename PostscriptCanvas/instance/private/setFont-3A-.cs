setFont:aFont

	| fInfo |

	aFont = currentFont ifTrue: [^self].
	currentFont _ aFont.
	self defineFont: aFont.
	fInfo _ self class postscriptFontInfoForFont: aFont.

	target 
		selectflippedfont: fInfo first
		size: (aFont pixelSize * fInfo second)
		ascent: aFont ascent.
