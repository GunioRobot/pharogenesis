testAddSeconds
	self assert: (aTime addSeconds: 1) = (Time readFrom: (ReadStream on: '12:34:57')).
	self assert: (aTime addSeconds: 60) = (Time readFrom: (ReadStream on: '12:35:56')).	
	self assert: (aTime addSeconds: 3600) = (Time readFrom: (ReadStream on: '13:34:56')).
	self assert: (aTime addSeconds: 24*60*60) = (Time readFrom: (ReadStream on: '12:34:56')).