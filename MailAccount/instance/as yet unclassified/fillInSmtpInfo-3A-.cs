fillInSmtpInfo: aClient 
	aClient hostName: self smtpServer.
	aClient port: aClient class defaultPortNumber.
	self shouldPerformSmtpAuthentication 
		ifTrue: 
			[aClient user: self smtpUserName.
			aClient password: self smtpPassword]