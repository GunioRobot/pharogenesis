filterToAnyChangeSet
	"Filter down only to messages present in ANY change set"

	self filterFrom:
		[:aClass :aSelector |
			ChangeSorter doesAnyChangeSetHaveClass: aClass andSelector: aSelector]
