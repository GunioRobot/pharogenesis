passwordsOnPublish
	^ self
		valueOfFlag: #passwordsOnPublish
		ifAbsent: [false]