writeSetup
	| settingsFile |

	settingsFile _ FileStream fileNamed: self settingsFileName.
	self account storeOn: settingsFile.
	settingsFile close.
