shouldPerformSmtpAuthentication
	^shouldPerformSmtpAuthentication 
		ifNil: [shouldPerformSmtpAuthentication := false]