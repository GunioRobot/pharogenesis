hours: hourInteger minutes: minInteger seconds: secInteger

	self setSeconds: (hourInteger * 3600) + (minInteger * 60) + secInteger.