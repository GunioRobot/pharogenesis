testInquiries

	self
		assert: week firstDate = '28 June 1998' asDate;
		assert: week lastDate = '4 July 1998' asDate;
		assert: week index = 5;
		assert: week duration = (7 days).
