recipients
	^ (Set withAll: (MailAddressParser addressesIn: self to))
		addAll: (MailAddressParser addressesIn: self cc);
		yourself