selectorsToBeIgnored

	 | deprecated private special |
	deprecated := #(
		#fromJulianDayNumber:
		#uniqueDateStringBetween:and:
		#daylightSavingsInEffectAtStandardHour:
		#daylightSavingsInEffect
		#asGregorian
		#asJulianDayNumber
		#day:year:
		#firstDayOfMonthIndex:
		#mmddyy
		#absoluteDaysToYear:
		#yearAndDaysFromDays:into:
		#week
		#month ).

	private := #( #julianDayNumber: ).

	special := #( #< #= #new #next #previous #printOn: #printOn:format: #storeOn: #fromString: ).

	^ super selectorsToBeIgnored, deprecated, private, special