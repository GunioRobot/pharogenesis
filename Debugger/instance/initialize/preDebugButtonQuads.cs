preDebugButtonQuads

	^Preferences eToyFriendly
		ifTrue: [
	{
	{'Store log' translated.	#storeLog. 	#blue. 	'write a log of the encountered problem' translated}.
	{'Abandon' translated.	#abandon. 	#black.	'abandon this execution by closing this window' translated}.
	{'Debug'	 translated.		#debug. 	#red. 	'bring up a debugger' translated}}]
		ifFalse: [
	{
	{'Proceed' translated.	#proceed. 	#blue. 	'continue execution' translated}.
	{'Abandon' translated.	#abandon. 	#black.	'abandon this execution by closing this window' translated}.
	{'Debug'	 translated.		#debug.		#red. 	'bring up a debugger' translated}}]
