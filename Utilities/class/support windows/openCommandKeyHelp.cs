openCommandKeyHelp
	"Open a window giving command key help."
	"Utilities openCommandKeyHelp"

	(StringHolder new contents: self commandKeyMappings)
		openLabel: 'Command Key Actions'
