example
	"This will quickly print all the numbers from 1 to 100 on the display,
	and then answer the default width and height of the string 'hello world'."
	"NewDisplayScanner example"
	| scanner |
	scanner _ self quickPrintOn: Display.
	0 to: 99 do: [: i | scanner drawString: i printString at: (i//10*20) @ (i\\10*12) ].
	^ (scanner stringWidth: 'hello world') @ (scanner lineHeight)