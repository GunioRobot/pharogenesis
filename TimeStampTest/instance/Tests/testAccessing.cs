testAccessing

	| d t |
	d := '1-10-2000' asDate.
	t := '11:55:00 am' asTime.

	self
		assert: timestamp date = d;
		assert: timestamp time = t.
