categories
	"Answer a collection of my categories, including the pseudo-categories '.unclassified.' and '.all.'. '.unclassified.' contains the orphaned messages that would otherwise not appear in any category. '.all.' contains all the messages in the database. Since these pseudo-categories are computed on the fly, there may be a noticable delay when one of them is selected."

	^(categories keys)
		add: '.all.';
		add: '.unclassified.';
		yourself