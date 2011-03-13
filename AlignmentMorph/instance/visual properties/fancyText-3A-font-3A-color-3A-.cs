fancyText: aString font: aFont color: aColor 
	| answer tm col |
	col := ColorTheme current dialog3DTitles
				ifTrue: [aColor]
				ifFalse: [aColor negated].
	tm := TextMorph new.
	tm beAllFont: aFont;
		 color: col;
		 contents: aString.
	answer := self inAColumn: {tm}.
	ColorTheme current dialog3DTitles
		ifTrue: [""
			tm addDropShadow.
			tm shadowPoint: 5 @ 5 + tm bounds center].
	tm lock.
	^ answer