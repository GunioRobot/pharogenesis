font: aFont
	super font: aFont.
	styler ifNotNil: [styler font: aFont]