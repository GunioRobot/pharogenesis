days: days hours: hours minutes: minutes seconds: seconds nanoSeconds: nanos

 	^ self nanoSeconds: 
			( ( (days * SecondsInDay) 
				+ (hours * SecondsInHour)
					+ (minutes * SecondsInMinute) 
						+ seconds ) * NanosInSecond )
							+ nanos.
