removeDuplicateFlapTabs
	"Remove flaps that were accidentally added multiple times"
	"Flaps removeDuplicateFlapTabs"
	| tabs duplicates same |
	SharedFlapTabs copy ifNil: [^self].
	tabs _ SharedFlapTabs copy.
	duplicates _ Set new.
	tabs do: [:tab |
		same _ tabs select: [:each | each wording = tab wording].
		same isEmpty not
			ifTrue: [
				same removeFirst.
				duplicates addAll: same]].
	SharedFlapTabs removeAll: duplicates