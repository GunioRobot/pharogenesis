testDuplicationsKinda
	|check uuid size |

	size _ 5000.
	check _ Set new: size.
	size timesRepeat: 
		[uuid _ UUID new.
		self shouldnt: [check includes: uuid].
		check add: uuid].
		