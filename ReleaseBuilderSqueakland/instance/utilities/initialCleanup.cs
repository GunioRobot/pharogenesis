initialCleanup
	"ReleaseBuilder new initialCleanup"

	Browser initialize.
	ChangeSorter removeChangeSetsNamedSuchThat:
		[:cs| cs name ~= ChangeSet current name].

	super initialCleanup