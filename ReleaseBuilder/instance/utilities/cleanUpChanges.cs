cleanUpChanges
	"Clean up the change sets"

	"ReleaseBuilder new cleanUpChanges"
	
	| projectChangeSetNames |

	"Delete all changesets except those currently used by existing projects."
	projectChangeSetNames := Project allSubInstances collect: [:proj | proj changeSet name].
	ChangeSet removeChangeSetsNamedSuchThat:
		[:cs | (projectChangeSetNames includes: cs) not].
