filterToNotAnyChangeSet
	"Filter down only to messages present in NO change set"

	self filterFrom:
		[:aClass :aSelector |
			(ChangeSorter doesAnyChangeSetHaveClass: aClass andSelector: aSelector) not]
