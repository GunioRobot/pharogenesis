readSetup
	| settingsFile |

	settingsFile _ FileStream oldFileNamed: self settingsFileName.
	account _ MailAccount readFrom: settingsFile.
	settingsFile close.
	