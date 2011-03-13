hasButton: buttonFlag
"do I have the button?"
	flags ifNil:[^false].
	^flags anyMask: buttonFlag