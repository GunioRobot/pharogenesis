timeZones

	^ {
		self offset:  0 hours name: 'Universal Time' abbreviation: 'UTC'.
		self offset:  0 hours name: 'Greenwich Mean Time' abbreviation: 'GMT'.
		self offset:  0 hours name: 'British Summer Time' abbreviation: 'BST'.
		self offset:  2 hours name: 'South African Standard Time' abbreviation: 'SAST'.
		self offset: -8 hours name: 'Pacific Standard Time' abbreviation: 'PST'.
		self offset: -7 hours name: 'Pacific Daylight Time' abbreviation: 'PDT'.
	}

