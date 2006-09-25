updateLabel: packagesShown
	"Update the label of the window."

	self setLabel: 'SqueakMap Package Loader (', packagesShown size printString,
			'/', model packages size printString, ')'