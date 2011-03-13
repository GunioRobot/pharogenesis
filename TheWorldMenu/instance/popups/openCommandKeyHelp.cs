openCommandKeyHelp
	"Open a window giving command key help."
	
	(StringHolder new contents: self commandKeyMappings)
		openLabel: 'Command Key Actions' translated
