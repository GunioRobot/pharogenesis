at: char put: form

	self cache at: (char asInteger + 1) put: (foregroundColor -> form).
