zapSelectionWith: aText 
	
	super zapSelectionWith: aText.
	"we always want userHasEdited to be performed, so that styling occurs after each change.
	super zapSelectionWith: will have done it when beginTypeInBlock is nil.
	So we only need to do it here when beginTypeInBlock is NOT nil"
	beginTypeInBlock ifNotNil:[self userHasEdited]