updateLabel: packagesShown
	"Update the label of the window."

	self setLabel: 'SqueakMap Package Loader (', packagesShown size printString,
			'/', squeakMap packages size printString, ')'