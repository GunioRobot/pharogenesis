setMacFile: fileName Type: typeString AndCreator: creatorString
	"Exported entry point for the VM. Needed for image saving only and no-op on anything but Macs."
	self export: true. "Must be exported for image file write"
	self var: #fileName type: 'char *'.
	self var: #typeString type: 'char *'.
	self var: #creatorString type: 'char *'.
	^self cCode: 'dir_SetMacFileTypeAndCreator(fileName, strlen(fileName), typeString, creatorString)'.