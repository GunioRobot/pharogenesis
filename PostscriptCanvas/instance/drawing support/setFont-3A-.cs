setFont:aFont
	aFont ~= currentFont ifTrue:[
		currentFont _ aFont.
		self defineFont:aFont.
		target selectflippedfont:(self postscriptFontNameForFont:aFont) size:aFont height * 0.9 ascent:aFont ascent.
				" the 0.9 is obviously a fudge factor.  I have to figure out how
 				  to figure out the actual font-size to request, neither #ascent nor #height
				  are correct." 
	]
