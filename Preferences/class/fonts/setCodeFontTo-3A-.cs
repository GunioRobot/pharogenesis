setCodeFontTo: aFont
	"Not currently sent, but once protocols are sorted out so that we can disriminate on whether a text object being launched is for code or not, will be reincorporated"

	Parameters at: #standardCodeFont put: aFont.
	Utilities replaceToolsFlap