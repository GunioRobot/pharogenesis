test1

	| localDirectory localFileName local resp |

	localDirectory _ FileDirectory default.
	localFileName _ 'superTest1.07Oct1611.cs'.
	local _ localDirectory oldFileNamed: localFileName.
	resp _ self putFile: local named: localFileName retry: false.
	local close.
	^resp
