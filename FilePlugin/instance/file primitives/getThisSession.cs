getThisSession
	"Exported entry point for the VM."
	self export: true. 
	^self cCode: 'sqFileThisSession()'.