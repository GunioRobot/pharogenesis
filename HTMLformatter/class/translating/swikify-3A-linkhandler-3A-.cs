swikify: aStringOrStream linkhandler: aBlock
	| formatter |
	formatter _ self new.
	formatter specialCharacter: $*.
	^formatter swikify: aStringOrStream linkhandler: aBlock