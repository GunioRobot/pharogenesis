Object
	subclass: #OldSocket
	instanceVariableNames: 'semaphore socketHandle readSemaphore writeSemaphore primitiveOnlySupportsOneSemaphore'
	classVariableNames:
		'Connected DeadServer InvalidSocket OtherEndClosed Registry RegistryThreshold TCPSocketType ThisEndClosed UDPSocketType Unconnected WaitingForConnection'
	poolDictionaries: ''
	category: 'Network-Kernel'