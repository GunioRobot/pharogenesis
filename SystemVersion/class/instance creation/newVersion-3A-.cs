newVersion: versionName
	| newVersion |
	newVersion _ self new version: versionName.
	newVersion
		highestUpdate: self current highestUpdate.
	Current _ newVersion
