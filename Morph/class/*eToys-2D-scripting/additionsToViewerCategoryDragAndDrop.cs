additionsToViewerCategoryDragAndDrop
	"Answer viewer additions for the 'drag & drop' category"

	^#(
		#'drag & drop'
 
		(
			(slot 'drop enabled' 'Whether drop is enabled' Boolean readWrite Player getDropEnabled Player setDropEnabled:)
			(slot 'resist being picked up' 'Whether a simple mouse-drag on this object should allow it to be picked up' Boolean readWrite Player getSticky Player setSticky:)
			(slot 'resist deletion' 'Whether this is resistant to easy removal via the pink X halo handle.' Boolean readWrite Player getResistsRemoval Player setResistsRemoval:)
			(slot 'be locked' 'Whether this object should be blind to all input' Boolean readWrite Player getIsLocked Player setIsLocked:)
		
		))