hours: hourInteger minutes: minInteger seconds: secInteger

	self 
		deprecated: 'Deprecated';
		setSeconds: (hourInteger * SecondsInHour) + (minInteger * SecondsInMinute) + secInteger.		
