doBackupJobs
	"This is just a wrapper so we don't have to restart the server loop when we add/remove jobs."

	| problemReport |
	BackupJobs do: [:block |
		problemReport _ nil.
		[block value] ifError: [:msg :rec |
			problemReport _ '*** ', rec asString, ': ', msg asString].
		problemReport ifNotNil: [^ problemReport]].

	^ 'Backup jobs completed'
