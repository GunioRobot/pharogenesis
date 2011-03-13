aReadThis
	"This class presents a view of a single change set.  A DualChangeSorter owns two of me.  The name pane across the top has a menu of things to do to the ChangeSet I am currently showing.  
	Renames of classes are not shown properly.  'Copy to other side' overwrites what was there if the other change set had the same method or class change.

	ChangeSorter new open.
	ChangeSorter allInstances inspect
	"