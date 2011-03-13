magnifyWithSmall
"	Also try:
	BitEditor openOnForm:
		(Form extent: 32@32 depth: Display depth)
	BitEditor openOnForm:
		((MaskedForm extent: 32@32 depth: Display depth)
		withTransparentPixelValue: -1)
"
	"Open a BitEditor viewing an area on the screen which the user chooses"
	| area form |
	area _ Rectangle fromUser.
	area isNil ifTrue: [^ self].
	form _ Form fromDisplay: area.
	self openOnForm: form

	"BitEditor magnifyWithSmall."