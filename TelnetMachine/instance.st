Model
	subclass: #TelnetMachine
	instanceVariableNames:
		'hostname port socket outputBuffer processingCommand commandChar lastInputChar displayLines cursorX cursorY foregroundColor displayMode commandParams requestedRemoteEcho remoteEchoAgreed '
	classVariableNames: 'CSSpecialChars DOChar DONTChar IAC OPTEcho WILLChar WONTChar '
	poolDictionaries: ''
	category: 'Network-TelNet WordNet'