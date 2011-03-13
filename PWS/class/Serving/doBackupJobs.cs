doBackupJobs
	"This is just a wrapper so we don't have to restart the server loop when we add/remove jobs."

	BackupJobs do: [:block |
		[block value] ifError: [:msg :rec | ^'*** ', rec asString, ': ', msg asString ]].

	^ 'Backup jobs completed'
