initialCleanup
	"ReleaseBuilder new initialCleanup"

	Smalltalk at: #Browser ifPresent:[:br| br initialize].
	ChangeSet removeChangeSetsNamedSuchThat:
		[:cs| cs name ~= ChangeSet current name].

	super initialCleanup