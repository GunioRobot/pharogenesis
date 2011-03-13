dateAndTimeFromSeconds: secondCount

	^ Array
		with: (Time fromSeconds: secondCount \\ 86400)
		with: (Date fromDays: secondCount // 86400)