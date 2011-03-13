testDuplicationsKinda
	|check uuid size |

	size := 5000.
	check := Set new: size.
	size timesRepeat: 
		[uuid := UUID new.
		self shouldnt: [check includes: uuid].
		check add: uuid].
		