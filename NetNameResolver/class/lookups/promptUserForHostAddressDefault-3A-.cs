promptUserForHostAddressDefault: defaultName
	"Ask the user for a host name and return its address. If the default name is the empty string, use the last host name as the default."
	"NetNameResolver promptUserForHostAddressDefault: ''"

	| default hostName serverAddr |
	Socket initializeNetwork.
	defaultName isEmpty
		ifTrue: [default _ DefaultHostName]
		ifFalse: [default _ defaultName].
	hostName _ FillInTheBlank
		request: 'Host name or address?'
		initialAnswer: default.
	hostName isEmpty ifTrue: [^ 0].
	serverAddr _ NetNameResolver addressForName: hostName timeout: 15.
	serverAddr = nil ifTrue: [self error: 'Could not find the address for ', hostName].
	hostName size > 0 ifTrue: [DefaultHostName _ hostName].
	^ serverAddr
