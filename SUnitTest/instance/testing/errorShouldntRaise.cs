errorShouldntRaise
	self 
		shouldnt: [self someMessageThatIsntUnderstood] 
		raise: SUnitNameResolver notificationObject
			