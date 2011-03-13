testColorPrintHtmlString
self assert: (Color red printHtmlString ) = ( Color red asHTMLColor allButFirst asUppercase).

