setFileAccessCallback: address
	self export: true. 
	self var: #address type: 'int'.
	^self cCode: 'sqSecFileAccessCallback((void *) address)'.