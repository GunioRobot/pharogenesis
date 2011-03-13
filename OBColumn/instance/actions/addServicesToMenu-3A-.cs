addServicesToMenu: aMenu
	| scan |
	scan _ self announcer announce: OBServiceScan.
	aMenu 
		addServices: scan services
		for: self requestor
		extraLines: #().
	