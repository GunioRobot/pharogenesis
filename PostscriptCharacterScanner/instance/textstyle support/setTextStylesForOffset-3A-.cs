setTextStylesForOffset:offset
	" default text style "
	font _ self textStyle defaultFont.
	emphasis _ 0.
	foregroundColor _ Color black.

	" set text styles defined at this point, these methods will set instance vars of myself "
	(paragraph text attributesAt: offset forStyle: paragraph textStyle) do: 
		[:att | att emphasizeScanner: self].

	" post-processing of 'emphasis' "
	self setActualFont: (font emphasized: emphasis)